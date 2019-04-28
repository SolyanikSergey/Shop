using Shop.API.App_Start;
using Shop.BLL.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
