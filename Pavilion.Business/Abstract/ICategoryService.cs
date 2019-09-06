using Pavilion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilion.Business.Abstract
{
    public interface ICategoryService 
    {
        Product GetById(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Delete(Category entity);
        void Update(Category entity);
    }
}
