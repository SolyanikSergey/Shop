using Autofac;
using Autofac.Integration.WebApi;
using Shop.API.Auth;
using Shop.BLL.Configuration;
using System.Reflection;
using System.Web.Http;

namespace Shop.API.Configuration
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<AuthorizationServerProvider>();

            builder = AutofacServicesConfig.RegisterBusinessServices(builder);
            builder = AutofacServicesConfig.RegisterRepositories(builder);

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();
            return Container;
        }
    }
}