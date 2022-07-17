using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class MovieImageManager : IMovieImageService
    {
        IMovieImageDal _movieImageDal;
        

        public MovieImageManager(IMovieImageDal movieImageDal)
        {
            _movieImageDal = movieImageDal;
        }

        public IResult Add(MovieImage movieImage)
        {
            
            movieImage.DateTime=DateTime.Now;
            _movieImageDal.Add(movieImage);
            return new SuccessResult();
        }

        public IResult Delete(MovieImage movieImage)
        {
            _movieImageDal.Delete(movieImage);
            return new SuccessResult();
        }

        public IDataResult<List<MovieImage>> GetAll()
        {
            return new SuccessDataResult<List<MovieImage>>(_movieImageDal.GetAll());
        }

        public IDataResult<MovieImage> GetById(int id)
        {
            return new SuccessDataResult<MovieImage>(_movieImageDal.Get(m=>m.Id==id));
        }

        public IResult Update(MovieImage movieImage)
        {
            _movieImageDal.Update(movieImage);
            return new SuccessResult();
        }

        private IResult MovieImageOfCount(int id)
        {
            var result = _movieImageDal.GetAll(m => m.MovieId ==id ).Any();
            if (result)
            {
                return new ErrorResult(Messages.MovieImageOfCount);
            }
            return new SuccessResult();
        }
    }
}
