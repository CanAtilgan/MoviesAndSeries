using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {

        IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var  userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
            
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userCheckRegister = _authService.UserExixts(userForRegisterDto.Email);
            if (userCheckRegister.Success)
            {
                return BadRequest(userCheckRegister.Message);
            }
            var userToRegister = _authService.Register(userForRegisterDto);
            if (!userToRegister.Success)
            {
                return BadRequest("Bilgilerinizi kontorl edin");
            }
            return Ok(userToRegister.Message);
        }

    }
}
