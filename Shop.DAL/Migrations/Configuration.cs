namespace Shop.DAL.Migrations
{
    using Shop.DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.DAL.Data.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shop.DAL.Data.ShopDbContext context)
        {
            context.Items.AddOrUpdate(new List<Item>()
            {
                new Item
                {
                    Name = "Test Product # 1",
                    Description = "Description for Test Product # 1",
                    Price = 20.95M,
                    Quantity = 100
                },
                new Item
                {
                    Name = "Test Product # 2 (out of stock)",
                    Description = "Description for Test Product # 2 (out of stock)",
                    Price = 20.15M,
                    Quantity = 0
                }
            }.ToArray());
        }
    }
}
