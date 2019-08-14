using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
    public interface IRepository<T> //Generic 
    {
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter);
        //If the user doesnt send an experssion, it will show all data (null value)
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
