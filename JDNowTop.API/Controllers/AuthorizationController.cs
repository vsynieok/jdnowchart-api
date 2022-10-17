using AutoMapper;
using JDNowTop.Data.Models;
using JDNowTop.Data.Models.DTO;
using JDNowTop.Logic.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace JDNowTop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthorizationController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("me")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDataDto user)
        {
            var result = await _userService.SignUp(user.UserName, user.Password);

            return result ? Ok() : BadRequest();
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserDataDto user)
        {
            var token = await _userService.LogIn(user.UserName, user.Password);
            if (token == null) return Unauthorized();

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { Token = tokenString });
        }
    }
}
