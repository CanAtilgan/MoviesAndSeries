using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        //bağımlığı azaltmak için daldan bağlanıyoruz , farklı bir veri tabanına geçersek sıkıntı olmasın diye 
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public IResult Add(Movie movie)
        {
            _movieDal.Add(movie);
            return new SuccessResult();
        }

        public IResult Delete(Movie movie)
        {
            _movieDal.Delete(movie);
           return new SuccessResult ();
        }

        public IDataResult<Movie> Get(int id)
        {
            return new SuccessDataResult<Movie>(_movieDal.Get(m => m.Id == id));
        }

        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll());
        }

        public IDataResult<List<MovieDetailDto>> GetMovieDetails()
        {
            return new SuccessDataResult<List<MovieDetailDto>> (_movieDal.GetMovieDetails());
        }

        public IResult Update(Movie movie)
        {
            _movieDal.Update(movie);
            return new SuccessResult(Messages.MovieUpdate);
        }
    }
}
