using System;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using System.Collections.Generic;

namespace QArte.Services.DTOMappers
{
	public static class BankAccountDTOMapperExtension
    {
		public static BankAccountDTO GetDTO(this BankAccount  bankAccount)
		{

			if(bankAccount is null)
			{

			}

			List<InvoiceDTO> invoiceDTOs = new List<InvoiceDTO>();
			foreach(Invoice invoice in bankAccount.Invoices)
			{
				List<FeeDTO> feeDTOs = new List<FeeDTO>();
				foreach(Fee fee in invoice.Fees)
				{
					feeDTOs.Add(new FeeDTO {ID= fee.ID, Amount = fee.Amount, Currency = fee.Currency, ExchangeRate = fee.ExchangeRate });
				}

                invoiceDTOs.Add(new InvoiceDTO
                {
                    ID = invoice.ID,
                    TotalAmount = invoice.TotalAmount,
                    InvoiceDate = invoice.InvoiceDate,
                    BankAccoundID = invoice.BankAccountID,
                    SettlementCycleID = invoice.SettlementCycleID,
					Fees = feeDTOs
                });

            }

			return new BankAccountDTO
			{
				ID = bankAccount.ID,
				IBAN = bankAccount.IBAN,
				BeneficiaryName = bankAccount.BeneficiaryName,
				StripeInfo = bankAccount.StripeInfo,
			};
		}
	}
}

