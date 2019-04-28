using System.Threading.Tasks;
using Shop.Common.Models;

namespace Shop.BLL.IServices
{
    public interface IOrderService
    {
        Task<ResultModel> BuyAsync(int itemId, string userId);
    }
}