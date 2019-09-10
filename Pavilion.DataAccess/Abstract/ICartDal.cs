using Pavilion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilion.DataAccess.Abstract
{
    public interface ICartDal : IRepository<Cart>
    {
        Cart GetByUserId(string userId);
        void DeleteFromCart(int cartId, int productId);
        void ClearCart(string cartId);
    }
}
