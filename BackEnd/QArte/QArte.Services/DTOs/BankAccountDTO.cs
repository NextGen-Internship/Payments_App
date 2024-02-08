using System;
using QArte.Persistance.PersistanceModels;
namespace QArte.Services.DTOs
{
	public class BankAccountDTO
	{
		public int ID { get; set; }
		public string IBAN { get; set; }
		public int PaymentMethodID { get; set; }

		public List<InvoiceDTO>? Invoices = new List<InvoiceDTO>();
	}
}

