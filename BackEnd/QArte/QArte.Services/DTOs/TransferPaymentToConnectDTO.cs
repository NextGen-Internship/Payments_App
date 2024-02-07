using System;
namespace QArte.Services.DTOs
{
	public class TransferPaymentToConnectDTO
	{
		public int userID { get; set; }
		public int amount { get; set; }
		public string currency { get; set; }
	}
}

