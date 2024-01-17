using System;
namespace QArte.Persistance.PersistanceModels
{
	public class Fee
	{
		public int ID { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
		public decimal ExchangeRate { get; set; }

	}
}

