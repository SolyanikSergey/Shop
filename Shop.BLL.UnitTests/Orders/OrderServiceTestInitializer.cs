using Moq;
using Shop.BLL.Services;
using Shop.DAL.Entities;
using Shop.DAL.IRepositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.BLL.UnitTests.Orders
{
    public class OrderServiceTestInitializer
    {
        private static string _userId = "cf666231-a086-4c0c-8b4a-894b82b52236";

        public static int ExistingItemId { get { return 3; } }
        public static int ExistingOutOfStockItemId { get { return 4; } }
        public static List<OrderHeader> Orders { get; private set; }
        public static IEnumerable<Item> Items { get; private set; }

        static OrderServiceTestInitializer()
        {
            Items = GetTestItems();
            Orders = GetTestOrderHeaders();
        }

        public OrderService InitializeService()
        {
            Mock<IGenericRepository<OrderHeader>> orderRepository = new Mock<IGenericRepository<OrderHeader>>();
            orderRepository.Setup(r => r.AddAsync(It.IsAny<OrderHeader>()))
               .Returns<OrderHeader>(x => 
               {
                   Orders.Add(x);
                   return Task.FromResult(x);
                });

            Mock<IGenericRepository<Item>> itemRepository = new Mock<IGenericRepository<Item>>();
            itemRepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(Items));
            itemRepository
                .Setup(r => r.GetAsync(It.IsAny<int>()))
                .Returns<int>(id => Task.FromResult(Items.FirstOrDefault(i => i.ItemId == id)));

            OrderService orderService = new OrderService(orderRepository.Object, itemRepository.Object);
            return orderService;
        }

        private static List<OrderHeader> GetTestOrderHeaders()
        {
            List<OrderHeader> data = new List<OrderHeader>();

            var item = Items.FirstOrDefault(i => i.ItemId == ExistingItemId);

            data.Add(new OrderHeader
            {
                OrderHeaderId = 1,
                IdentityUserId = _userId,
                OrderDate = DateTime.Now,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        OrderItemId = 1,
                        OrderHeaderId = 1,
                        Item = item,
                        ItemId = item.ItemId,
                        Price = item.Price,
                        Count = 1
                    }
                }
            });

            return data;
        }

        private static List<Item> GetTestItems()
        {
            List<Item> data = new List<Item>();

            data.Add(new Item
            {
                ItemId = ExistingItemId,
                Name = "Test Item # 3",
                Price = 25,
                Quantity = 12
            });

            data.Add(new Item
            {
                ItemId = ExistingOutOfStockItemId,
                Name = "Test Item # 4",
                Price = 49,
                Quantity = 0
            });

            return data;
        }
    }
}