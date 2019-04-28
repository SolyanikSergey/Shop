using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.BLL.Services;
using Shop.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.BLL.UnitTests.Items
{
    [TestClass]
    public class ItemServiceUnitTest
    {
        private static ItemService _itemService;

        [ClassInitialize]
        public static void Initialize(TestContext typeContext)
        {
            ItemServiceTestInitializer itemServiceTestInitializer = new ItemServiceTestInitializer();
            _itemService = itemServiceTestInitializer.InitializeService();
        }

        [TestMethod]
        public async Task Check_get_entities_count()
        {
            // arrange
            IEnumerable<ItemViewModel> itemViewModels;

            // act
            itemViewModels = await _itemService.GetAllAsync();

            // assert
            Assert.AreEqual(ItemServiceTestInitializer.Items.Count(), itemViewModels.Count(), "Item Service returned different count, not like mocked DbContext!");
        }
    }
}
