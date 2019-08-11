using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<T, TContext> : IRepository<T>
         //Restricting generic paramaters
         where T : class
         where TContext : DbContext, new()


    {
        public void Create(T entity)
        {
            using (var context= new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }
        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter=null)
        {
            using (var context = new TContext())
            {

                return filter == null //Is the filter null?
                    ? context.Set<T>().ToList() //If it is null
                    : context.Set<T>().Where(filter).ToList(); //If it is not null, send filter

            }
        }

        public T GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id);
            }


        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(filter).SingleOrDefault(); //Will send single or null value 
            }
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
