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

namespace QArte.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokennService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(IUserService userService,ITokennService tokenService,
            IConfiguration configuration, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userService = userService;
            _tokenService = tokenService;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Response<string>> Register(RegisterDTO registerUser)
        {
            var userExist = await _userService.FindByEmailAsync(registerUser.Email);

            if(userExist != null)
            {
                return new Response<string>()
                {
                    Succeed = false,
                    Message = "User with this Email already exists!"
                };
            }
            User user = new User();

            var token = await RegisterUser(registerUser, user);

            return token != null ? new Response<string> { Succeed = true, Data = token } : new Response<string> { Succeed = false, Message = "Invalid Registration" };
        }

        // register new user
        private async Task<string?> RegisterUser(RegisterDTO registerUser, User user)
        {
            user.FirstName = registerUser.FirstName;
            user.LastName = registerUser.LastName;
            user.Email = registerUser.Email;
            
            
            var token = _tokenService.GenerateJwtToken(user);
            //CreateAsync creates new account and hash the password
            var isCreated = await _userManager.CreateAsync(user, registerUser.Password);

            if (!isCreated.Succeeded)
            {
                return null;
            }

            return token;
        }

        public async Task<Response<string>> Login(LoginDTO loginUser)
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

        public async Task<GoogleToken?> ValidateGoogleTokenAsync(string googleToken)
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

        public Task<Response<string>> GoogleLoginAsync(LoginWithGoogleDTO googleLogin)
        {
           throw new NotImplementedException();
        }
    }

}

