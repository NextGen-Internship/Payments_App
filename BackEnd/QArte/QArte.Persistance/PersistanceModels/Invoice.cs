using System;
namespace QArte.Persistance.PersistanceModels
{
	public class Invoice
	{

		public Invoice()
		{
			Fees = new HashSet<Fee>();
		}

		public int ID { get; set; }
		public decimal TotalAmount { get; set; }
		public DateTime InvoiceDate { get; set; }

		public int UserID { get; set; }
		public virtual User User{ get; set; }

		public int SettlementCycleID { get; set; }
		public virtual SettlementCycle SettlementCycle { get; set; }

		public virtual ICollection<Fee> Fees { get; set; }
		
	}
}

