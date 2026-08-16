using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs;
using Salam_Application.Services_Interfces;
using Salam_Domain.Interfaces;
using Salam_Infrastructure.Repositories;

namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;
        public AuthController( IAuthService authService , IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }


        [HttpPost ("Register")]
        public async Task<IActionResult> Register ([FromBody]RegisterDto registerDto)
        {
            var isCreated = await _authService.Register(registerDto);

            if (!isCreated)
                return BadRequest("User already exists");

            return Ok("User registered successfully");
        }


        [HttpPost ("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.Login(loginDto);

            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new
            {
                Token = token
            });
        }






    }
}
