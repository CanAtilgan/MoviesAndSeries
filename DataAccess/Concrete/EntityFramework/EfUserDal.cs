using Core.DataAccess.EntityFramewrok;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EntitiyRepositoryBase<User, MovieAndSeriesContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(var contex = new MovieAndSeriesContext())
            {
                var result = from op in contex.OperationClaims
                             join uo in contex.UserOperationClaims
                             on op.Id equals uo.OperationClaimId
                             where uo.UserId == user.Id
                             select new OperationClaim { Id=op.Id , Name=op.Name};
                return result.ToList();
                

            }
        }
    }
}
