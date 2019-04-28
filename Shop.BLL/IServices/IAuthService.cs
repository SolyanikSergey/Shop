using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.ViewModel;

namespace Shop.BLL.IServices
{
    public interface IAuthService
    {
        Task<IdentityUser> FindUser(string userName, string password);
        Task<IdentityResult> RegisterUser(UserViewModel userViewModel);
        Task<ClaimsIdentity> CreateIdentityAsync(IdentityUser user);
    }
}