using System;
using QArte.Persistance.PersistanceModels;
using QArte.Persistance.Enums;

namespace QArte.Services.DTOs
{
	public class UserDTO
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string PictureURL { get; set; }
		public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string StripeAccountID { get; set; }
		public string IBAN { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string postalCode { get; set; }
        public bool isBanned { get; set; }
		public int RoleID { get; set; }
        public int BankAccountID { get; set; }
        public int SettlementCycleID { get; set; }
        public ESettlementCycles SettlementCycleEnum { get; set; }
		public EPaymentMethods paymentMethodsEnum { get; set; }
		public ERoles roleEnum { get; set; }

        public List<PageDTO>? Pages { get; set; }
    }
}

