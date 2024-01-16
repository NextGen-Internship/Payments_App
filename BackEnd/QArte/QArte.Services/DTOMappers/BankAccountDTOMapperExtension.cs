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
                throw new ApplicationException("This BankAccount is null");
			}

            List<InvoiceDTO> invoiceDTOs = new List<InvoiceDTO>();
            foreach (Invoice invoice in bankAccount.Invoices)
            {
                List<FeeDTO> feeDTOs = new List<FeeDTO>();
                foreach (Fee fee in invoice.Fees)
                {
                    feeDTOs.Add(new FeeDTO { ID = fee.ID, Amount = fee.Amount, Currency = fee.Currency, ExchangeRate = fee.ExchangeRate });
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
                    PaymentMethodID = bankAccount.PaymentMethodID,
                    Invoices = invoiceDTOs
                };
            }


        public static BankAccount GetEntity(this BankAccountDTO bankAccountDTO)
        {
            if (bankAccountDTO is null)
            {
                throw new ApplicationException("This BankAccount is null");
        
            }
            List<Invoice> invoices = new List<Invoice>();
            if (bankAccountDTO.Invoices != null)
            { 
                foreach (InvoiceDTO invoiceDTO in bankAccountDTO.Invoices)
                {
                    if (invoiceDTO.Fees == null)
                    {
                        break;
                    }
                    List<Fee> fees = new List<Fee>();
                    foreach (FeeDTO feeDTO in invoiceDTO.Fees)
                    {
                        fees.Add(new Fee { ID = feeDTO.ID, Amount = feeDTO.Amount, Currency = feeDTO.Currency, ExchangeRate = feeDTO.ExchangeRate });
                    }

                    invoices.Add(new Invoice
                    {
                        ID = invoiceDTO.ID,
                        TotalAmount = invoiceDTO.TotalAmount,
                        InvoiceDate = invoiceDTO.InvoiceDate,
                        BankAccountID = invoiceDTO.BankAccoundID,
                        SettlementCycleID = invoiceDTO.SettlementCycleID,
                        Fees = fees
                    });

                }
            }

            return new BankAccount
            {
                ID = bankAccountDTO.ID,
                IBAN = bankAccountDTO.IBAN,
                BeneficiaryName = bankAccountDTO.BeneficiaryName,
                StripeInfo = bankAccountDTO.StripeInfo,
                PaymentMethodID = bankAccountDTO.PaymentMethodID,
                Invoices = invoices
            };
            
        }

	}
}

