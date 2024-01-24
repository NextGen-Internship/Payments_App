using System;

namespace QArte.Services.DTOs
{
	public class FeeDTO
	{
		public int ID { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
		public decimal ExchangeRate { get; set; }

        public static explicit operator List<object>(FeeDTO v)
        {
            throw new NotImplementedException();
        }
    }
}

