using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _userdal.GetAll();
        }
    }
}
