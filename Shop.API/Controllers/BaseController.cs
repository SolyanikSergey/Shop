using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Shop.API.Controllers
{
    public class BaseController : ApiController
    {
        public string UserId
        {
            get { return User.Identity.GetUserId(); }
        }
    }
}
