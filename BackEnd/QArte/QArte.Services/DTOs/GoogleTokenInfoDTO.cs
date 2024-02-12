using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace QArte.Persistance.PersistanceModels
{
    public class GoogleTokenInfoDTO
    {
        [Required]
        public bool Succeed { get; set; }

        public string? Message { get; set; }

        [JsonProperty("First_name")]
        public string? FirstName { get; set; }

        [JsonProperty("Last_name")]
        public string? LastName { get; set; }

        [JsonProperty("Email")]
        public string? Email { get; set; }
    }
}