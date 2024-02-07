using QArte.Persistance.PersistanceConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QArte.Services.DTOs;
using QArte.Persistance.Enums;
using QArte.Persistance.PersistanceModels;

namespace QArte.Services.ServiceInterfaces
{
    public interface IAuthenticationService : IService
    {
        Task<Response<string>> Login(Login loginUser);
        Task<Response<string>> GoogleLoginAsync(LoginWithGoogle googleLogin);
        Task Logout();
    }
}