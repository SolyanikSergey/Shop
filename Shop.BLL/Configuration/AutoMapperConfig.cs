using AutoMapper;
using Shop.DAL.Entities;
using Shop.ViewModel;

namespace Shop.BLL.Configuration
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Item, ItemViewModel>().ReverseMap();
                config.CreateMap<OrderHeader, OrderHeaderViewModel>().ReverseMap();
                config.CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
            });
        }
    }
}
