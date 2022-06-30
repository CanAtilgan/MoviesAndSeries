using Core.DataAccess.EntityFramewrok;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EntitiyRepositoryBase<Category,MovieAndSeriesContext>,ICategoryDal
    {
    }
}
