using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesImageController : ControllerBase
    {
        IMovieImageService _movieImageService;

        public MoviesImageController(IMovieImageService movieImageService)
        {
            _movieImageService = movieImageService;
        }

        [HttpPost("add")]
        public IActionResult Add(MovieImage movieImage)
        {
            var result = _movieImageService.Add(movieImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(MovieImage movieImage)
        {
            var result = _movieImageService.Update(movieImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int Id)
        {
            var movieImage = _movieImageService.GetById(Id).Data;
            var result = _movieImageService.Delete(movieImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _movieImageService.GetAll();
            return Ok(result);
        }

    }
}
