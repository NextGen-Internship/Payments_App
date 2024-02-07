using System;
namespace QArte.Persistance.PersistanceModels
{
	public class Fee
	{
		public int ID { get; set; }
		public long Amount { get; set; }
		public string Currency { get; set; }
		public double ExchangeRate { get; set; }

	}
}

