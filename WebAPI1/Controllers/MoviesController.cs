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


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _movieService.GetAll();
            if (result.Success)
            {        //DURUM KODU "OK"
                return Ok(result);
            }
            return BadRequest(result);


        }
    }
}
