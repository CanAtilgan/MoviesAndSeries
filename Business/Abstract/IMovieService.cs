using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IResult Add(Movie movie);
        IResult Delete(Movie movie);
        IResult Update(Movie movie);
        IDataResult<List<Movie>> GetAll();
        IDataResult<Movie> Get(int id);
        IDataResult<List<MovieDetailDto>> GetMovieDetails();
    }
}
