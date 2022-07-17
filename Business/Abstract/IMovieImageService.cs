using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMovieImageService
    {
        IResult Add(MovieImage movieImage);
        IResult Delete(MovieImage movieImage);
        IResult Update(MovieImage movieImage);
        IDataResult<List<MovieImage>> GetAll();
        IDataResult<MovieImage> GetById(int id);
    }
}
