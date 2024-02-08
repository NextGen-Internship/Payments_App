using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using Microsoft.AspNetCore.Authorization;
using QArte.Persistance.PersistanceConfigurations;

namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerUser)
        {
            try
            {
                var response = await _authenticationService.Register(registerUser);

                return response.Succeed == true ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO loginUser)
        {
            try
            {
                var response = await _authenticationService.Login(loginUser);

                return response.Succeed == true ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] LoginWithGoogleDTO googleLogin)
        {
            try
            {
                var response = await _authenticationService.GoogleLoginAsync(googleLogin);

                return response.Succeed == true ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Logout")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _authenticationService.Logout();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}




