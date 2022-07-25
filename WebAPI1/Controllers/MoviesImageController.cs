using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileStoragesController: ControllerBase
    {
        IMovieImageService _movieImageService;

        public FileStoragesController(IMovieImageService movieImageService)
        {
            _movieImageService = movieImageService;
        }

        [HttpPost("add")]
        public IActionResult Add(FileRequestDto fileRequestDto)
        {
            var result = _movieImageService.Add(fileRequestDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        //[HttpPost("update")]
        //public IActionResult Update(MovieImage movieImage)
        //{
        //    var result = _movieImageService.Update(movieImage);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}
       
        [HttpPost("delet")]
        public IActionResult Delete(FileRequestDto fileUploadRequest)
        {
            var result = _movieImageService.Delete(fileUploadRequest);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
