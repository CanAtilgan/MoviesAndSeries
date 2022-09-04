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
        IFileService _fileService;

        public FileStoragesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("add")]
        public IActionResult Add(FileRequestDto fileRequestDto)
        {
            var result = _fileService.Add(fileRequestDto);
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
            var result = _fileService.Delete(fileUploadRequest);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _fileService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fileService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest("Htalı istek");
        }
    }
}
