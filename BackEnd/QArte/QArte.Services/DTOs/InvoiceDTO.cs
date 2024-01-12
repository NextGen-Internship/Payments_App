using System;
namespace QArte.Services.DTOs
{
	public class InvoiceDTO
	{
		public int ID { get; set; }
		public decimal TotalAmount { get; set; }
		public DateTime InvoiceDate { get; set; }
		public int BankAccoundID { get; set; }
		public int SettlementCycleID { get; set; }

		public List<FeeDTO> Fees;

	}
}

