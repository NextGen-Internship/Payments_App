using System.ComponentModel.DataAnnotations;

namespace QArte.Persistance.PersistanceModels
{
    public class User 
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

        public bool isBanned { get; set; }

        public string StripeAccountID { get; set; }

        public string Country { get; set; }

        public string address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }


        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string? PictureUrl { get; set; }

        public string PhoneNumber { get; set; }

        public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        public int BankAccountID { get; set; }
        public virtual BankAccount BankAccount { get; set; }

        public int SettlementCycleID { get; set; }
        public virtual SettlementCycle SettlementCycle { get; set; }

        public ICollection<Page>? Pages { get; set; }
    }
}

