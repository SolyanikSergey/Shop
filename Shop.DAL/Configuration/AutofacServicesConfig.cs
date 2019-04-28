using Autofac;
using Shop.DAL.Data;
using Shop.DAL.IRepositories.Generic;
using Shop.DAL.Repositories.Generic;

namespace Shop.DAL.Configuration
{
    public class AutofacRepositoriesConfig
    {
        public static ContainerBuilder RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ShopDbContext>();

            builder.RegisterGeneric(typeof(GenericRepository<>))
               .As(typeof(IGenericRepository<>));

            return builder;
        }
    }
}
