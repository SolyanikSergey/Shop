using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.BLL.IServices;
using Shop.DAL.Data;
using Shop.ViewModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly ShopDbContext _shopDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthService(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(shopDbContext));
        }

        public async Task<IdentityResult> RegisterUser(UserViewModel userViewModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userViewModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userViewModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
            => await _userManager.FindAsync(userName, password);

        public async Task<ClaimsIdentity> CreateIdentityAsync(IdentityUser user)
        {
            var userStore = new UserStore<IdentityUser>(_shopDbContext);
            var manager = new UserManager<IdentityUser, string>(userStore);
            ClaimsIdentity identity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer);
            return identity;
        }
    }
}
