using Microsoft.AspNet.Identity;
using Shop.BLL.IServices;
using Shop.Common.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shop.API.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<ResultModel> Post(int itemId)
        {
            string userId = User.Identity.GetUserId();
            return await _orderService.BuyAsync(itemId, userId);
        }
    }
}
