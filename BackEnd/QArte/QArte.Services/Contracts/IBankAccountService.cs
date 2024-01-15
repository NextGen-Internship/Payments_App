using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.Contracts
{
	public interface IBankAccountService : ICRUDshared<BankAccountDTO>
	{

		Task<IBankAccountService> GetByIBANAsync(string IBAN);
		Task<IBankAccountService> GetByIDAsync(int id);
		Task<bool> BankAccountExists(int id, string IBAN);
		Task<IEnumerable<BankAccountDTO>> GetBankAccountsByBeneficiaryNameAsync(string BeneficiaryName);
		Task<IEnumerable<BankAccountDTO>> GetBankAccountsByPaymentMethod(EPaymentMethods ePaymentMethod);

	}
}

