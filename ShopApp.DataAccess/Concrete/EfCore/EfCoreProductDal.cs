using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, ShopContext>, IProductDal
    {

        public Product GetProductDetails(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page)
        {
            using (var context = new ShopContext())  //defining the context as ShopContext
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category)) //filtering
                {
                    products = products //Reaching to the products and checking if it has any item in it
                         .Include(i => i.ProductCategories)
                         .ThenInclude(i => i.Category)
                         .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.ToList();
            }
        }
    }
}
