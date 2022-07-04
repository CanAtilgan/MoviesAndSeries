using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //field ,soyuta gevşek bağlılık :loosely coupled
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService=userService;
        }

        public IActionResult Get()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
