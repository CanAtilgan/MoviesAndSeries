using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(Category category);
        List<Category> GetAll();
        Category GetById(int id);
    }
}
