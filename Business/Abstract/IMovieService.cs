using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMovieService
    {
        void Add(Movie movie);
        void Delete(Movie movie);
        void Update(Movie movie);
        List<Movie> GetAll();
        Movie Get(int id);
    }
}
