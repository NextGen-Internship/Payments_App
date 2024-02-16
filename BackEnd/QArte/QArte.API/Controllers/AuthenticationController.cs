using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using Microsoft.AspNetCore.Authorization;
using QArte.Persistance.PersistanceConfigurations;
using Newtonsoft.Json;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
//new
namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly ITokennService _tokenService;

        public AuthenticationController(IAuthenticationService authService, IUserService userService,
                                        IConfiguration configuration,ITokennService tokenService)
        {
            _authService = authService;
            _userService = userService;
            _configuration = configuration;
            _tokenService = tokenService;

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginUser)
        {
            try
            {
                var response = await _authService.Login(loginUser);
                return response.Succeed == true ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured:{ex.Message}");
            }
        }


        //[HttpPost]
        //[Route("google-login")]
        //public async Task<IActionResult> GoogleLogin([FromBody] UserDTO user, [FromQuery] string token)
        //{
        //    try
        //    {
        //        //create object LoginWithGoogleDTO and the needed information
        //        var googleLogin = new LoginWithGoogleDTO
        //        {
        //            UserInfo = user,
        //            GoogleToken = token
        //        };
        //        var response = await _authService.GoogleLoginAsync(token);

        //        return response.Succeed ? Ok(response) : BadRequest(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}

        [HttpPost]
        [Route ("google-signIn")]
        //public async Task<IActionResult> SignIn([FromBody] string token)
        public async Task<IActionResult> SignIn([FromBody] GoogleLoginDTO token)
        {
            
            try
            {
                var validation = await _authService.ValidateGoogleTokenAsync(token.Token);//if valid token
                if (validation == null || string.IsNullOrEmpty(validation.Email))
                {
                    return BadRequest(new { UserExists = false, Token = ""});
                }

                var existingUser = await _userService.FindByEmailAsync(validation.Email);

                var jwtToken = _tokenService.GenerateJwtToken(existingUser);
                //var successResponse = new Response<string>()
                //{
                //    Succeed = true,
                //    Message = "Successfull.",
                //    Data = jwtToken
                //};
                return Ok(new { UserExists = true, Token = jwtToken });
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] LoginWithGoogleDTO googleUser)
        {
            try
            {
                var user = googleUser.UserInfo;
                var validation = await _authService.ValidateGoogleTokenAsync(googleUser?.GoogleToken);
                if (validation == null || string.IsNullOrEmpty(validation.Email))
                {
                    return BadRequest("Invalid Google token.");
                }

                var jwtToken = _tokenService.GenerateJwtToken(user);

                var successResponse = new Response<string>()
                {
                    Succeed = true,
                    Message = "Successfull.",
                    Data = jwtToken
                };

                // create new user
                //user.Email = validation.Email; //here the email from the token
                // generate new password
                //user.Password = GenerateRandomPassword();

                // send email with new password

                //create user
                user.Password = GenerateRandomPassword();
                var createUserResponse = await _userService.PostAsync(user);

                if(createUserResponse.ID == 0)
                {
                    return BadRequest(new Response<string>()
                    {
                        Succeed = false,
                        Message = "User not created",
                    });
                }
               
            // generate jwt token for the new user 
               
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private string GenerateRandomPassword(int length = 12)
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var passwordChars = new char[length];

            // Using RandomNumberGenerator for generating random bytes
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                for (int i = 0; i < length; i++)
                {
                    int pos = randomBytes[i] % allowedChars.Length;
                    passwordChars[i] = allowedChars[pos];
                }
            }

            return new string(passwordChars);
        }


        //validate google id token and returns info about the user after successfull login
        private async Task<GoogleTokenInfoDTO?> ValidateGoogleTokenAsync(string googleToken)
        {
            using (var httpClient = new HttpClient())
            {
                var validationEndpoint = _configuration["GoogleOAuth:ValidationEndpoint"] + googleToken;
                var response = await httpClient.GetAsync(validationEndpoint);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GoogleTokenInfoDTO>(responseContent);
            }
        }

        //[HttpPost]
        //[Route("google-login")]
        //public async Task<IActionResult> GoogleLogin([FromBody] LoginWithGoogleDTO googleLogin)
        //{
        //    try
        //    {
        //        var response = await _authService.GoogleLoginAsync(googleLogin);

        //        return response.Succeed == true ? Ok(response) : BadRequest(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}
    }
}