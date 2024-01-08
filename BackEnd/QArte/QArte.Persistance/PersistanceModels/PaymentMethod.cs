using System;
using QArte.Persistance.Enums;
namespace QArte.Persistance.PersistanceModels
{
	public class PaymentMethod
	{
		public int ID { get; set; }
		public int UserID { get; set; }

		public virtual User User { get; set; }
		public EPaymentMethods PaymentMethods { get; set; }
	}
}

