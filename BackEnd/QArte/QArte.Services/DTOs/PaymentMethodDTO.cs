using System;
using QArte.Persistance.Enums;
using System.Collections.Generic;

namespace QArte.Services.DTOs
{
	public class PaymentMethodDTO
	{
		public int ID { get; set; }
		public EPaymentMethods paymentName { get; set; }

		//public List<BankAccountDTO> BankAccounts { get; set; } = new List<BankAccountDTO>();
    }
}

