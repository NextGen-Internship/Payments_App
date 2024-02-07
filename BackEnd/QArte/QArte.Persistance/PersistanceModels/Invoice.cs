using System;
namespace QArte.Persistance.PersistanceModels
{
	public class Invoice
	{
		public int ID { get; set; }
		public long TotalAmount { get; set; }
		public DateTime InvoiceDate { get; set; }

		public int BankAccountID { get; set; }
		public virtual BankAccount BankAccount{ get; set; }

		public int FeeID { get; set; }
		public virtual Fee Fee { get; set; }
		
	}
}

