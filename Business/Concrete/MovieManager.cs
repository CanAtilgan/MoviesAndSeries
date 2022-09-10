using Business.Abstract;
using Business.BussinesAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        //bağımlığı azaltmak için daldan bağlanıyoruz , farklı bir veri tabanına geçersek sıkıntı olmasın diye 
        IMovieDal _movieDal;
        //ICategoryDal _categoryDal; BU YAPI YANLIŞTIR. BİR ENTİTY MANAGER , KENDİSİ HARİÇ BAŞKA DALI ENJECTE EDEMEZ 
        ICategoryService _categoryService;
        IFileService _fileService;
        public MovieManager(IMovieDal movieDal,ICategoryService categoryService,IFileService fileService) //dependency injection
        {
            _movieDal = movieDal;
            _categoryService = categoryService;
            _fileService = fileService;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieValidator))]
        public IResult Add(Movie movie)
        {
            //validation mantığı
            //var context = new ValidationContext<Movie>(movie);
            //MovieValidator validator = new MovieValidator();
            //var result = validator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            //bu yapıda kötü , iç blok çorbaya dönmesin diye AOP ile , atribute olarak yaparız-aspact
            //ValidationTool.Validation(new MovieValidator(),movie);
            IResult result = BusinessRules.Run(CheckIfMoviveNameExists(movie.MovieName));//result'a atarak , uymayan kuralın sonucu o olur ve onu altta çalıştırığ hatayı gösterir. Bu yapıda poliformizim var 
            if (result!=null)
            {
                return result;
            }
   
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

        [SecuredOperation("admin")]
        public IDataResult<List<Movie>> GetAll()
        {
            var movies = _movieDal.GetAll();
            foreach (var movie in movies)
            {
                movie.Photo = _fileService.GetMovieUri(movie.Id);
            }
           return new SuccessDataResult<List<Movie>>(movies);
        }

        public IDataResult<List<MovieDetailDto>> GetMovieDetails()
        {
            return new SuccessDataResult<List<MovieDetailDto>> (_movieDal.GetMovieDetails());
        }

        public IDataResult<string> GetMovieFile(int id)
        {
            var movieFiles = _fileService.Get(id);
            var test = movieFiles.Data.EntityId;
            var file = $@"C:/Api/Assets/Movie/{test.Value}/{movieFiles.Data.FileName}{movieFiles.Data.DataType.Trim()}_";
            var uri = new Uri(file);
            return new SuccessDataResult<string>(uri.AbsolutePath);
        }

        public IResult Update(Movie movie)
        {
            _movieDal.Update(movie);
            return new SuccessResult(Messages.MovieUpdate);
        }

        private IDataResult<string> SearcFile(int entityId)
        {
            var result = _fileService.GetMovieUri(entityId);
            return new SuccessDataResult<string>(data:"url");
        }
        private IResult CheckIfMoviveNameExists(string moviName)
        {
            var result = _movieDal.GetAll(m=>m.MovieName == moviName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ExistingMovie);
            }
            return new SuccessResult();
        }

        

    }
}

//var selectFile = _movieDal.GetAll();
//foreach (var movie in selectFile) { var fileId = movie.Id; };
////var convertId = file;