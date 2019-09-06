using Pavilion.DataAccess.Abstract;
using Pavilion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Pavilion.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, ShopContext> , ICategoryDal
    {
        
    }
}
