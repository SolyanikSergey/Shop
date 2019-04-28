using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.BLL.Services;
using Shop.DAL.Entities;
using Shop.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.BLLTests.Items
{
    [TestClass]
    public class EntityDataServiceUnitTest
    {
        private static ItemService _itemService;
        private static IEnumerable<Item> _items;

        [ClassInitialize]
        public static void Initialize(TestContext typeContext)
        {
            ItemServiceTestInitializer itemServiceTestInitializer = new ItemServiceTestInitializer();

            _itemService = itemServiceTestInitializer.InitializeService();
            _items = itemServiceTestInitializer.GetTestItems();
        }

        [TestMethod]
        public async Task Check_get_entities_count()
        {
            // arrange
            IEnumerable<ItemViewModel> itemViewModels;

            // act
            itemViewModels = await _itemService.GetAllAsync();

            // assert
            Assert.AreEqual(_items.Count(), itemViewModels.Count(), "Item Service returned different count, not like mocked DbContext!");
        }
    }
}
