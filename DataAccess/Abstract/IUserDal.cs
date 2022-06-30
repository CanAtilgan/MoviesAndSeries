using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        

    }
}
