using System;
using System.Text;
using QArte.API.Handlers;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QArte.Persistance.PersistanceConfigurations;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

//namespace QArte.API.Controllers
//{
//	[ApiController]
//	[Route("api/[controller]")]
//	public class AuthenticationController : ControllerBase
//	{

//		private readonly IAuthService _auth;

//		public AuthenticationController(IAuthService auth)
//		{
//			_auth = auth;
//		}

//        [HttpPost]
//        [ProducesResponseType(200)]
//        [ProducesResponseType(401)]
//        public async Task<ActionResult<IEnumerable<ResponseAuthDTO>>> Login(RequestAuthDTO model)
//        {
//            return Ok(await _auth.AuthenticateAsync(model));
//        }
//    }
//}

//namespace QArte.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthenticationController : ControllerBase
//    {
//        private readonly UserManager<User> _userManager;
//        //private readonly JwtConfig _jwtConfig;
//        private readonly IConfiguration _configuration;

//        //public AuthenticationController(UserManager<IdentityUser> userManager, JwtConfig jwtConfig)
//        public AuthenticationController(UserManager<User> userManager, IConfiguration configuration)
//        {
//            _userManager = userManager;
//            //_jwtConfig = jwtConfig;
//            _configuration = configuration;
//        }

//        [HttpPost]
//        [Route("Register")]
//        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDTO requestDTO)
//        {
//            //Validate the incoming request
//            if (ModelState.IsValid)
//            {
//                //we need to check if the email already exist
//                var user_exist = await _userManager.FindByEmailAsync(requestDTO.Email);

//                if (user_exist != null)
//                {
//                    return BadRequest(new AuthResult()
//                    {
//                        Result = false,
//                        Errors = new List<string>()
//                        {
//                            "Email already exist."
//                        }
//                    });
//                }

//                //creating a user
//                var new_user = new User()
//                {
//                    Email = requestDTO.Email,
//                    UserName = requestDTO.Email
//                };

//                var is_created = await _userManager.CreateAsync(new_user, requestDTO.Password);

//                if (is_created.Succeeded)
//                {
//                    //generate the token
//                    var token = GenerateJwtToken(new_user);

//                    return Ok(new AuthResult()
//                    {
//                        Result = true,
//                        Token = token
//                    });
//                }

//                return BadRequest(new AuthResult()
//                {
//                    Errors = new List<string>()
//                    {
//                        "Server error."
//                    },
//                    Result = false
//                });
//            }

//            return BadRequest();
//        }


//        [HttpPost]
//        [Route("Login")]
//        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO loginRequest)
//        {
//            if (ModelState.IsValid)
//            {
//                //chech if the user
//                var existing_user = await _userManager.FindByEmailAsync(loginRequest.Email);

//                if (existing_user == null)
//                    return BadRequest(new AuthResult()
//                    {
//                        Errors = new List<string>()
//                    {
//                        "Invalid payload."
//                    },
//                        Result = false
//                    });

//                var isCorrect = await _userManager.CheckPasswordAsync(existing_user, loginRequest.Password);

//                if (!isCorrect)
//                    return BadRequest(new AuthResult()
//                    {
//                        Errors = new List<string>()
//                        {
//                            "Invalid credentials."
//                        },
//                        Result = false
//                    });

//                var jwtToken = GenerateJwtToken(existing_user);

//                return Ok(new AuthResult()
//                {
//                    Token = jwtToken,
//                    Result = true
//                });
//            }

//            return BadRequest(new AuthResult()
//            {

//                Errors = new List<string>()
//                    {
//                        "Invalid payload"
//                    },
//                Result = false
//            });
//        }


//        private string GenerateJwtToken(User user)
//        {
//            var jwtTokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig").Value);

//            //token descriptor
//            var tokenDescriptor = new SecurityTokenDescriptor()
//            {
//                Subject = new ClaimsIdentity(new[]
//                {
//                    new Claim("Id", user.ID.ToString()),
//                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
//                    new Claim(JwtRegisteredClaimNames.Email, value: user.Email),
//                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
//                }),
//                Expires = DateTime.Now.AddHours(1),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
//            };

//            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
//            return jwtTokenHandler.WriteToken(token);
//        }

//    }
//}




//first_working_code
//namespace QArte.API.Controllers
//{
//	[ApiController]
//	[Route("api/[controller]")]
//	public class AuthenticationController : ControllerBase
//	{
//		private readonly UserManager<IdentityUser> _userManager;
//		//private readonly JwtConfig _jwtConfig;
//		private readonly IConfiguration _configuration;

//		//public AuthenticationController(UserManager<IdentityUser> userManager, JwtConfig jwtConfig)
//		public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration)
//		{
//			_userManager = userManager;
//			//_jwtConfig = jwtConfig;
//			_configuration = configuration;
//		}

//		[HttpPost]
//		[Route("Register")]
//		public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDTO requestDTO)
//		{
//			//Validate the incoming request
//			if (ModelState.IsValid)
//			{
//				//we need to check if the email already exist
//				var user_exist = await _userManager.FindByEmailAsync(requestDTO.Email);

//				if (user_exist != null)
//				{
//					return BadRequest(new AuthResult()
//					{
//						Result = false,
//						Errors = new List<string>()
//						{
//							"Email already exist."
//						}
//					});
//				}

//				//creating a user
//				var new_user = new IdentityUser()
//				{
//					Email = requestDTO.Email,
//					UserName = requestDTO.Email
//				};

//				var is_created = await _userManager.CreateAsync(new_user, requestDTO.Password);

//				if (is_created.Succeeded)
//				{
//					//generate the token
//					var token = GenerateJwtToken(new_user);

//					return Ok(new AuthResult()
//					{
//						Result = true,
//						Token = token
//					});
//				}

//				return BadRequest(new AuthResult()
//				{
//					Errors = new List<string>()
//					{
//						"Server error."
//					},
//					Result = false
//				});
//			}

//			return BadRequest();
//		}


//		[HttpPost]
//		[Route("Login")]
//		public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO loginRequest)
//		{
//			if (ModelState.IsValid)
//			{
//				//chech if the user
//				var existing_user = await _userManager.FindByEmailAsync(loginRequest.Email);

//				if (existing_user == null)
//					return BadRequest(new AuthResult()
//					{
//						Errors = new List<string>()
//					{
//						"Invalid payload."
//					},
//						Result = false
//					});

//				var isCorrect = await _userManager.CheckPasswordAsync(existing_user, loginRequest.Password);

//				if (!isCorrect)
//					return BadRequest(new AuthResult()
//					{
//						Errors = new List<string>()
//						{
//							"Invalid credentials."
//						},
//						Result = false
//					});

//				var jwtToken = GenerateJwtToken(existing_user);

//				return Ok(new AuthResult()
//				{
//					Token = jwtToken,
//					Result = true
//				});
//			}

//			return BadRequest(new AuthResult()
//			{

//				Errors = new List<string>()
//					{
//						"Invalid payload"
//					},
//				Result = false
//			});
//		}


//		private string GenerateJwtToken(IdentityUser user)
//		{
//			var jwtTokenHandler = new JwtSecurityTokenHandler();
//			var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig").Value);

//			//token descriptor
//			var tokenDescriptor = new SecurityTokenDescriptor()
//			{
//				Subject = new ClaimsIdentity(new[]
//				{
//					new Claim("Id", user.Id),
//					new Claim(JwtRegisteredClaimNames.Sub, user.Email),
//					new Claim(JwtRegisteredClaimNames.Email, value: user.Email),
//					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//					new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
//				}),
//				Expires = DateTime.Now.AddHours(1),
//				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
//			};

//			var token = jwtTokenHandler.CreateToken(tokenDescriptor);
//			return jwtTokenHandler.WriteToken(token);
//		}

//	}
//}