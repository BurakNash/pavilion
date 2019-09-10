using Pavilion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilion.Business.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);
        List<Order> GetOrders(string userId);
    }
}
