using System;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using System.Collections.Generic;

namespace QArte.Services.DTOMappers
{
	public static class BankAccountDTOMapperExtencion
    {
		public static BankAccountDTO GetDTO(this BankAccount  bankAccount)
		{
			return new BankAccountDTO
			{
				ID = bankAccount.ID,
				IBAN = bankAccount.IBAN,
				BeneficiaryName = bankAccount.BeneficiaryName,
				StripeInfo = bankAccount.StripeInfo,
				Invoices = bankAccount.Invoices.Select(x => $"ID:{x.ID}; TotalAmount:{x.TotalAmount}; InvoiceDate:{x.InvoiceDate}; BankAccountID:{x.BankAccountID}; SettlementCycleID:{x.SettlementCycleID}; Fees:{x.Fees.Select(f=>$"Amount:{f.Amount}; Currency:{f.Currency}")}").ToList()

			};
		}
	}
}

