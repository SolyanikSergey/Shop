using Shop.BLL.IServices;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shop.API.Controllers
{
    public class ItemsController : BaseController
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<IHttpActionResult> Get() => Ok(await _itemService.GetAllAsync());
    }
}
