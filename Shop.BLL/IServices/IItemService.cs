using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.ViewModel;

namespace Shop.BLL.IServices
{
    public interface IItemService
    {
        Task<IEnumerable<ItemViewModel>> GetAllAsync();
    }
}