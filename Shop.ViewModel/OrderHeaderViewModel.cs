using Shop.Common.Models;
using System;
using System.Collections.Generic;

namespace Shop.ViewModel
{
    public class OrderHeaderViewModel
    {
        public int OrderHeaderId { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string IdentityUserId { get; set; }

        public ICollection<OrderItemViewModel> OrderItems { get; set; }
    }
}
