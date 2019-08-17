using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase //providing blueprint for inherited classes
    {
        public static void Seed ()
        {
            var context = new ShopContext();
            //If the database is not updated with migration
            //If there is any data received, SeedData call will not be sent
            if (context.Database.GetPendingMigrations().Count()==0)
            {
                //If there is no category listed
                if(context.Categories.Count()==0)
                {
                    context.Categories.AddRange(Categories);
                }
                if(context.Products.Count()==0)
                {
                    context.Products.AddRange(Products);
                }
                context.SaveChanges();
            }
        }
        private static Product[] Products =
     {
            new Product() {Name= "Samsung S5", Price=500, ImageUrl="1.jpg", Description="<p>What a phone!</p>"},
            new Product() {Name= "Samsung S6", Price=600, ImageUrl="2.jpg", Description="<p>What a phone!</p>"},
            new Product() {Name= "Samsung S7", Price=650, ImageUrl="3.jpg", Description="<p>What a phone!</p>"},
            new Product() {Name= "Samsung S8", Price=2000, ImageUrl="4.jpg", Description="<p>What a phone!</p>"},
            new Product() {Name= "Samsung S9", Price=2000, ImageUrl="5.jpg", Description="<p>What a phone!</p>"},
            new Product() {Name= "Iphone 6", Price=2000, ImageUrl="6.jpg", Description="<p>What a phone!</p>"},
            new Product() {Name= "Iphone 7", Price=2000, ImageUrl="7.jpg", Description="<p>What a phone!</p>"}
            
        };
        private static Category[] Categories =
        {
            new Category() {Name= "Phones"},
            new Category() {Name= "Computer"}
        };
    }
}
