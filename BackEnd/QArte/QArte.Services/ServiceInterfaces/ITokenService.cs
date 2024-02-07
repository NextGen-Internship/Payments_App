using QArte.Persistance.PersistanceModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QArte.Services.ServiceInterfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}