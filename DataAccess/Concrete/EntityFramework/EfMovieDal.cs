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
        public List<MovieDetailDto> GetMovieDetails()
        {
            using(MovieAndSeriesContext context = new MovieAndSeriesContext())
            {
                var result = from m in context.Movies
                             join c in context.Categories
                             on m.CategoryId equals c.Id
                             select new MovieDetailDto 
                             {   MoviesId=m.Id,
                                 MovieName = m.MovieName,
                                 CategoryName =c.CategoryName
                             };

                return result.ToList( );
            }
            
        }
    }
}
