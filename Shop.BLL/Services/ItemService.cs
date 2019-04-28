using AutoMapper;
using Shop.BLL.IServices;
using Shop.DAL.Entities;
using Shop.DAL.IRepositories.Generic;
using Shop.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IGenericRepository<Item> _itemRepository;

        public ItemService(IGenericRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemViewModel>> GetAllAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            return Mapper.Map<IEnumerable<Item>, IEnumerable<ItemViewModel>>(items);
        }
    }
}
