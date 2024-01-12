using System;
using System.Collections.Generic;

namespace QArte.Services.DTOs
{
	public class PaymentMethodDTO
	{
		public int ID { get; set; }
		public string name { get; set; }

		public List<string> BankAccounts;
	}
}

