using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

//new
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

        [JsonProperty("Username")]
        public string? Username { get; set; }

        [JsonProperty("Address")]
        public string? Address { get; set; }

        [JsonProperty("Country")]
        public string? Country { get; set; }

        [JsonProperty("City")]
        public string? City { get; set; }

        [JsonProperty("postalCode")]
        public string? Postalcode { get; set; }

        

    }
}