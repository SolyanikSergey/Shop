using Moq;
using Shop.BLL.Services;
using Shop.DAL.Entities;
using Shop.DAL.IRepositories.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.BLL.UnitTests.Items
{
    public class ItemServiceTestInitializer
    {
        public static IEnumerable<Item> Items { get; private set; }

        static ItemServiceTestInitializer()
        {
            Items = GetTestItems();
        }

        public ItemService InitializeService()
        {
            Items = GetTestItems();

            Mock<IGenericRepository<Item>> itemRepository = new Mock<IGenericRepository<Item>>();
            itemRepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(Items));

            ItemService itemService = new ItemService(itemRepository.Object);
            return itemService;
        }

        private static List<Item> GetTestItems()
        {
            List<Item> data = new List<Item>();

            data.Add(new Item
            {
                Name = "Test Item # 1",
                Price = 100,
                Quantity = 20
            });

            data.Add(new Item
            {
                Name = "Test Item # 2",
                Price = 20.9M,
                Quantity = 90
            });

            return data;
        }
    }
}