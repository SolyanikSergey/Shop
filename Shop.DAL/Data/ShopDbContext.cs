using Microsoft.AspNet.Identity.EntityFramework;
using Shop.DAL.Entities;
using System.Data.Entity;

namespace Shop.DAL.Data
{
    public class ShopDbContext : IdentityDbContext<IdentityUser>
    {
        public ShopDbContext() : base("name=ShopDbEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
