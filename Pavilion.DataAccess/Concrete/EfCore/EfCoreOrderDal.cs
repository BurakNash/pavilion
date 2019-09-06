using Pavilion.DataAccess.Abstract;
using Pavilion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilion.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderDal : EfCoreGenericRepository<Order, ShopContext> , IOrderDal
    {
    }
}
