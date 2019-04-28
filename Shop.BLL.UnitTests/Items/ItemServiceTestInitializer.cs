using Moq;
using Shop.BLL.Services;
using Shop.DAL.Entities;
using Shop.DAL.IRepositories.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.BLLTests.Items
{
    public class ItemServiceTestInitializer
    {
        public ItemService InitializeService()
        {
            IEnumerable<Item> entities = GetTestItems();

            Mock<IGenericRepository<Item>> itemRepository = new Mock<IGenericRepository<Item>>();
            itemRepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(entities));

            ItemService itemService = new ItemService(itemRepository.Object);
            return itemService;
        }

        public List<Item> GetTestItems()
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