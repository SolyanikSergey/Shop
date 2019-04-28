using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.BLL.Services;
using Shop.Common.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.BLL.UnitTests.Orders
{
    [TestClass]
    public class OrderServiceUnitTest
    {
        private static OrderService _orderService;
        private string _userId = "6aaf6244-40cd-4bb2-991b-f2747b859aa0";

        [ClassInitialize]
        public static void Initialize(TestContext typeContext)
        {
            OrderServiceTestInitializer orderServiceTestInitializer = new OrderServiceTestInitializer();
            _orderService = orderServiceTestInitializer.InitializeService();
        }

        [TestMethod]
        public async Task Check_buy_nonexistent_item()
        {
            // arrange
            ResultModel resultModel;

            // act
            resultModel = await _orderService.BuyAsync(int.MaxValue, _userId);

            // assert
            Assert.IsFalse(resultModel.IsSuccess, $"Service returned succeed result, but an error was expected!");
        }

        [TestMethod]
        public async Task Check_buy_out_of_stock_item()
        {
            // arrange
            ResultModel resultModel;

            // act
            resultModel = await _orderService.BuyAsync(OrderServiceTestInitializer.ExistingOutOfStockItemId, _userId);

            // assert
            Assert.IsFalse(resultModel.IsSuccess, $"Service returned succeed result, but an error was expected!");
        }

        [TestMethod]
        public async Task Check_buy_in_stock_item()
        {
            // arrange
            ResultModel resultModel;
            int orderCountBeforeBuying;
            int orderCountAfterBuying;

            // act
            orderCountBeforeBuying = OrderServiceTestInitializer.Orders.Count();
            resultModel = await _orderService.BuyAsync(OrderServiceTestInitializer.ExistingItemId, _userId);
            orderCountAfterBuying = OrderServiceTestInitializer.Orders.Count();

            // assert
            Assert.IsTrue(resultModel.IsSuccess, $"Service returned failed result, but an success was expected!");
            Assert.AreEqual(orderCountBeforeBuying + 1, orderCountAfterBuying, "Order Service didn't save new Order!");
        }
    }
}
