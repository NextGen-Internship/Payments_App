using QArte.Persistance.PersistanceConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QArte.Services.DTOs;
using QArte.Persistance.Enums;
using QArte.Persistance.PersistanceModels;
using Microsoft.Win32;

namespace QArte.Services.ServiceInterfaces
{
    public interface IAuthenticationService : IService
    {
        Task<Response<string>> Login(LoginDTO loginUser);
        Task<Response<string>> GoogleLoginAsync(LoginWithGoogleDTO googleLogin);
        Task<GoogleTokenInfoDTO?> ValidateGoogleTokenAsync(string googleToken);
    }
}
//new