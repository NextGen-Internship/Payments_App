using System;
using System.Collections.Generic;


namespace QArte.Persistance.PersistanceModels
{
	public class BankAccount
	{
		public BankAccount()
		{
			Invoices = new HashSet<Invoice>();
		}
		public int ID { get; set; }
		public string IBAN { get; set; }

		public int PaymentMethodID { get; set; }
		public virtual PaymentMethod PaymentMethod { get; set; }

		public ICollection<Invoice>? Invoices { get; set; }
	}
}

