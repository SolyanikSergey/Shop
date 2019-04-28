using Autofac;
using Shop.BLL.IServices;
using Shop.BLL.Services;
using Shop.DAL.Configuration;

namespace Shop.BLL.Configuration
{
    public class AutofacServicesConfig
    {
        public static IContainer Container { get; set; }

        public static ContainerBuilder RegisterBusinessServices(ContainerBuilder builder)
        {
            builder.RegisterType<AuthService>()
               .As<IAuthService>();

            builder.RegisterType<ItemService>()
                .As<IItemService>();

            builder.RegisterType<OrderService>()
                .As<IOrderService>();

            return builder;
        }

        public static ContainerBuilder RegisterRepositories(ContainerBuilder builder)
        {
            return AutofacRepositoriesConfig.RegisterRepositories(builder);
        }
    }
}
