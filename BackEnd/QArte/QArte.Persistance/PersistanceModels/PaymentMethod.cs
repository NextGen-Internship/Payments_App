using System;
using QArte.Persistance.Enums;

namespace QArte.Persistance.PersistanceModels
{
	public class PaymentMethod
	{

		public PaymentMethod(){
			//BankAccounts = new HashSet<BankAccount>();
		}

		public int ID { get; set; }

		public EPaymentMethods PaymentMethods { get; set; }

		//public virtual ICollection<BankAccount> BankAccounts { get; set; }
	}
}

