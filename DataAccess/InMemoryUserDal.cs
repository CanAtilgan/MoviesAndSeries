using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryUserDal : IUserDal
    {
        List<User> _users;

        public InMemoryUserDal()
        {
            _users = new List<User> { new User { Id = 1, FirstName = "cAN",Email="atilgan@gmail.com" },
                                      new User { Id = 2, FirstName = "Hasan",Email="hasan@gmail.com" },
                                      new User { Id = 3, FirstName = "Uğur",Email="ugur@gmail.com" },};
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(User user)
        {
                              //_users.içindegez"foreachle"(u içinde u=id si gönderilen user id'sine eşit varsa ona işlem yap              
            User UserToDelete = _users.SingleOrDefault(u => u.Id == user.Id);

             _users.Remove(UserToDelete);
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            User UserToUpdate = _users.SingleOrDefault(u => u.Id == user.Id);
            //user.Adress = UserToUpdate.Adress;
            //user.Email = UserToUpdate.Email;
            //user.Password = UserToUpdate.Password;
            //user.FirstName = UserToUpdate.FirstName;
           
        }
    }
}
