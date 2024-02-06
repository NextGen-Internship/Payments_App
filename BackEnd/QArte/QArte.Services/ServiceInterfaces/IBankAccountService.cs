using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.ServiceInterfaces
{
	public interface IBankAccountService : ICRUDshared<BankAccountDTO>
	{

		Task<BankAccountDTO> GetByIBANAsync(string IBAN);
		Task<BankAccountDTO> GetByIDAsync(int id);
		public Task<bool> BankAccountExists(int id, string IBAN);
		Task<IEnumerable<BankAccountDTO>> GetBankAccountsByPaymentMethod(string ePaymentMethod);
		Task<BankAccountDTO> AddInvoice(int BankAccID, InvoiceDTO obj);

    }
}

