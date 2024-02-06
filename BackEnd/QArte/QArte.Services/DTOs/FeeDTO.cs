using System;

namespace QArte.Services.DTOs
{
	public class FeeDTO
	{
		public int ID { get; set; }
		public long Amount { get; set; }
		public string Currency { get; set; }
		public double ExchangeRate { get; set; }
    }
}