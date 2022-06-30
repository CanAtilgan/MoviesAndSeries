using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Movie movie)
        {
            _movieDal.Add(movie);
        }

        public void Delete(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAll()
        {
            return _movieDal.GetAll();
        }

        public void Update(Movie movie)
        {
            _movieDal.Update(movie);
        }
    }
}
