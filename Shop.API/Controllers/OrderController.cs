using Shop.BLL.IServices;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shop.API.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IHttpActionResult> Post(int itemId)
        {
            var resultModel = await _orderService.BuyAsync(itemId, UserId);
            return resultModel.IsSuccess 
                ? Ok(resultModel) as IHttpActionResult
                : BadRequest(resultModel.Message);
        }
    }
}
