using Shop.BLL.IServices;
using Shop.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shop.API.Controllers
{
    public class ItemsController : ApiController
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<IEnumerable<ItemViewModel>> Get() => await _itemService.GetAllAsync();
    }
}
