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
            if (context.Database.GetPendingMigrations().Count()==0)
            {
                //If there is no category listed
                if(context.Categories.Count()==0)
                {
                    context.Categories.AddRange(Categories);
                }
                
            }
        }
        private static Category[] Categories=
        {
            new Category() {Name= "Phones"},
            new Category() {Name= "Computer"}
        }
    }
}
