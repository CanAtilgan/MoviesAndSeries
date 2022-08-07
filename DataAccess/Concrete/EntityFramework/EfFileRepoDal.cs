using Core.DataAccess;
using Core.DataAccess.EntityFramewrok;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFileRepoDal : EntitiyRepositoryBase<FileRepo, MovieAndSeriesContext>, IFileRepoDal
    {

    }
    
}
