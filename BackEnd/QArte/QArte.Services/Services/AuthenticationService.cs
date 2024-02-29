using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;

using QArte.Persistance;
//new
namespace QArte.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokennService _tokenService;
        private readonly IConfiguration _configuration;


        public AuthenticationService(IUserService userService,
                                        ITokennService tokenService,
                                        IConfiguration configuraion)
        {
            _userService = userService;
            _tokenService = tokenService;
            _configuration = configuraion;
        }

        public async Task<Response<string>> Login(LoginDTO loginUser)
        {
            var user = await _userService.FindByEmailAsync(loginUser.Email); //from db
            if (user != null)
            {
                //here result is boolean value
                var result = _userService.CheckByPasswordSignIn(user, loginUser.Password);
                if (result == false)
                {
                    return new Response<string>()
                    {
                        Succeed = false,
                        Message = "Invalid password"
                    };
                }

                var jwtToken = _tokenService.GenerateJwtToken(user);
                return new Response<string>()
                {
                    Succeed = true,
                    Message = "Successfull login.",
                    Data = jwtToken,
                    ID = user.ID,
                    picUrl = user.PictureURL
                };
            }
            return new Response<string>
            {
                Succeed = false,
                Message = "User not found"
              
            };

        }

        public async Task<Response<string>> GoogleLoginAsync(LoginWithGoogleDTO googleLogin)
        {
            var validation = await ValidateGoogleTokenAsync(googleLogin?.GoogleToken);
            if (validation == null || string.IsNullOrEmpty(validation?.Email))
            {
                return new Response<string>
                {
                    Succeed = false,
                    Message = "Invalid token."
                };
            }

            //var email = ;
            //if the token is valid
            //i use the email from the validation 
            //for checking if a user with this email already exist 
            var existingUser = await _userService.FindByEmailAsync(validation.Email);
            if (existingUser == null)
            {
                var newRegUser = new UserDTO
                {
                    Email = validation.Email,
                    FirstName = validation.FirstName,
                    LastName = validation.LastName,
                };

                try
                {
                    existingUser = await _userService.PostAsync(newRegUser);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"An error occurred: {ex.Message}");
                    return new Response<string>
                    {
                        Succeed = false,
                        Message = $"Error while creating a user: {ex.Message}."
                    };
                }
            }

            var jwtToken = _tokenService.GenerateJwtToken(existingUser);
            return new Response<string>
            {
                Succeed = true,
                Message = "Successfull.",
                Data = jwtToken
            };
        }

        //validate google id token and returns info about the user after successfull login
        public async Task<GoogleTokenInfoDTO?> ValidateGoogleTokenAsync(string googleToken)
        {
            using (var httpClient = new HttpClient())
            {
                var validationEndpoint = _configuration["GoogleOAuth:ValidationEndpoint"] + googleToken ?? "";
                var response = await httpClient.GetAsync(validationEndpoint);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GoogleTokenInfoDTO>(responseContent);
            }
        }



    }

}