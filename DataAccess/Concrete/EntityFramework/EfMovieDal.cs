using Core.DataAccess.EntityFramewrok;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMovieDal : EntitiyRepositoryBase<Movie, MovieAndSeriesContext>, IMovieDal
    {
        public MovieDetailDto GetMovieDetails(int id)
        {
            using(MovieAndSeriesContext context = new MovieAndSeriesContext())
            {
                var result = from m in context.Movies where m.Id == id
                             join c in context.Categories
                             on m.CategoryId equals c.Id
                             join p in context.FileRepos
                             on m.Photo equals Convert.ToString(p.Id) into crm
                             from p in crm.DefaultIfEmpty()
                             select new MovieDetailDto ()
                             {   MovieId=m.Id,
                                 MovieName = m.MovieName,
                                 CategoryName =c.CategoryName,
                                 Description =m.Description,
                                 Photo = p.FileName
                             };

                return result.FirstOrDefault();
            }
            
        }
    }
}
