using System;
using System.ComponentModel.DataAnnotations;

namespace QArte.Persistance.PersistanceModels
{
	public abstract class User
	{
		public int ID { get; set; }

        [MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }

        [MinLength(2), MaxLength(20)]
        public string LastName { get; set; }

        [MinLength(2), MaxLength(20)]
        public string UserName { get; set; }

        [MinLength(8)]
        public string Password { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? DeletedOn { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string PictureUrl { get; set; }

        public string PhoneNumber { get; set; }



    }
}

