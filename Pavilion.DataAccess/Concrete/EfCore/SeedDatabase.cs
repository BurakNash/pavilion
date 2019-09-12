using Microsoft.EntityFrameworkCore;
using Pavilion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pavilion.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategory);
                }

                context.SaveChanges();
            }
        }

        private static Category[] Categories = {
            new Category() { Name="Necklace"},
            new Category() { Name="Ring"},
            new Category() { Name="Earring"}
        };

        private static Product[] Products =
        {
            new Product(){ Name="Ring 1", Price=10, ImageUrl="1.jpg", Description="<p>Description here</p>"},
            new Product(){ Name="Ring 2", Price=20, ImageUrl="2.jpg", Description="<p>Description here</p>"},
            new Product(){ Name="Ring 3", Price=30, ImageUrl="3.jpg", Description="<p>Description here</p>"},
            new Product(){ Name="Necklace 1", Price=40, ImageUrl="4.jpg", Description="<p>Description here</p>"},
            new Product(){ Name="Necklace 2", Price=50, ImageUrl="5.jpg", Description="<p>Description here</p>"},
            new Product(){ Name="Necklace 3", Price=60, ImageUrl="6.jpg", Description="<p>Description here</p>"},
            new Product(){ Name="Earring 1", Price=70, ImageUrl="7.jpg", Description="<p>Description here</p>"}
        };


        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory() { Product= Products[1],Category= Categories[1]},
            new ProductCategory() { Product= Products[2],Category= Categories[1]},
            new ProductCategory() { Product= Products[3],Category= Categories[1]},
            new ProductCategory() { Product= Products[4],Category= Categories[2]},
            new ProductCategory() { Product= Products[5],Category= Categories[2]},
            new ProductCategory() { Product= Products[6],Category= Categories[2]},
            new ProductCategory() { Product= Products[7],Category= Categories[3]}
        };
    }
}
