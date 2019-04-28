using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Common.Models;
using System;
using System.Collections.Generic;

namespace Shop.DAL.Entities
{
    public class OrderHeader
    {
        public int OrderHeaderId { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
