using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QArte.Services.ServiceInterfaces
{
    public interface ITokennService
    {
        string GenerateJwtToken(UserDTO user);
        
    }
}
//new