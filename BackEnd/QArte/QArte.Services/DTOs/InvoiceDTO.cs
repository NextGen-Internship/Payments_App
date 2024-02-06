using System;
namespace QArte.Services.DTOs
{
	public class InvoiceDTO
	{
		public int ID { get; set; }
		public long TotalAmount { get; set; }
		public DateTime InvoiceDate { get; set; }
		public int BankAccountID { get; set; }
		public int FeeID { get; set; }
	}
}