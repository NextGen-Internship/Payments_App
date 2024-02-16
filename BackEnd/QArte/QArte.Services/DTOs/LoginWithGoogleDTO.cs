using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QArte.Services.DTOs
{
    public class LoginWithGoogleDTO 
    {
        public string? GoogleToken { get; set; }
        public UserDTO UserInfo { get; set; }
        
    }
}
//new