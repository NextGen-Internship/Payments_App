using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QArte.Services.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        //private readonly UserManager<User> _userMAnager;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(IUserService userService,ITokenService tokenService,
            IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = userService;
            _tokenService = tokenService;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Response<string>> Login(Login loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if (user != null)
            {
                var ruesult = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);
                if (ruesult.Succeeded)
                {
                    var jwtToken = _tokenService.GenerateJwtToken(user);
                    return new Response<string>()
                    {
                        Succeed = true,
                        Data = jwtToken
                    };
                }
            }
            return new Response<string>()
            {
                Succeed = false,
                Message = "Invalid User"
            };
        }

        

        private async Task<GoogleToken?> ValidateGoogleTokenAsync(string googleToken)
        {
            using (var httpClient = new HttpClient())
            {
                var validationEndpoint = _configuration["ValidationEndpoint"] + googleToken;
                var response = await httpClient.GetAsync(validationEndpoint);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GoogleToken>(responseContent);
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public Task<Response<string>> GoogleLoginAsync(LoginWithGoogle googleLogin)
        {
            throw new NotImplementedException();
        }
    }

}

