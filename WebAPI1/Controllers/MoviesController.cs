using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IMovieService _movieService;
       

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
           
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _movieService.Get(id);
            if (result.Success)
            {        //DURUM KODU "OK"
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _movieService.GetAll();
            if (result.Success)
            {        //DURUM KODU "OK"
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Movie movie)
        {
            var result = _movieService.Add(movie);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]    
        public IActionResult Update(Movie movie)
        {
            var result = _movieService.Update(movie);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
       
        [HttpGet("moviedetails")]
        public IActionResult GetMovieDetails(int id)
        {
            var result = _movieService.GetMovieDetailById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    
        [HttpGet("getfile")]
       public IActionResult GetMovieFile(int id)
        {
            var result= _movieService.GetMovieFile(id);
            return Ok(result);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _movieService.GetAllByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
