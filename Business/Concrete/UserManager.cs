using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(User user)
        {
            _userdal.Add(user);
            return new SuccessResult("Başarılı");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll(),Messages.UsersListed);
        }

        public IResult Update(User user)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorResult(Messages.UserUpdateError);
            }
            _userdal.Update(user);
            return new SuccessResult(Messages.UserUpdate);

        }
    }
}
