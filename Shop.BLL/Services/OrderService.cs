﻿using AutoMapper;
using Shop.BLL.IServices;
using Shop.Common.Models;
using Shop.DAL.Entities;
using Shop.DAL.IRepositories.Generic;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<OrderHeader> _orderHeaderRepository;
        private readonly IGenericRepository<Item> _itemRepository;

        public OrderService(IGenericRepository<OrderHeader> orderHeaderRepository,
                            IGenericRepository<Item> itemRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
            _itemRepository = itemRepository;
        }

        public async Task<ResultModel> BuyAsync(int itemId, string userId)
        {
            var item = await _itemRepository.GetAsync(itemId);
            var itemAvailableResult = CheckIsItemAvalableToBuy(item, itemId);
            if (!itemAvailableResult.IsSuccess) return itemAvailableResult;

            var orderHeader = GenerateOrderHeader(item, userId);
            var placedOrder = await _orderHeaderRepository.AddAsync(orderHeader);
            var placedOrderViewModel = Mapper.Map<OrderHeader, OrderHeaderViewModel>(placedOrder);

            return new ResultModel
            {
                IsSuccess = true,
                Message = $"Order with id '{placedOrderViewModel.OrderHeaderId}' was successfully placed",
                Data = placedOrderViewModel
            };
        }

        private ResultModel CheckIsItemAvalableToBuy(Item item, int itemId)
        {
            if (item == null)
                return new ResultModel { IsSuccess = false, Message = $"There are no item with id '{itemId}'" };

            if (item.Quantity < 1)
                return new ResultModel { IsSuccess = false, Message = $"Sorry, item with id '{item.ItemId}' is out of stock" };

            return new ResultModel { IsSuccess = true };
        }

        private OrderHeader GenerateOrderHeader(Item item, string userId)
        {
            var orderHeader = new OrderHeader
            {
                IdentityUserId = userId,
                OrderDate = DateTime.Now,
                OrderStatus = OrderStatus.Placed,
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem
                    {
                        ItemId = item.ItemId,
                        Price = item.Price,
                        Count = 1
                    }
                }
            };

            return orderHeader;
        }
    }
}
