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
                invoiceDTOs.Add(new InvoiceDTO
                {
                    ID = invoice.ID,
                    TotalAmount = invoice.TotalAmount,
                    InvoiceDate = invoice.InvoiceDate,
                    BankAccountID = invoice.BankAccountID,
                    FeeID = invoice.FeeID
                });
            }
                

                return new BankAccountDTO
                {
                    ID = bankAccount.ID,
                    IBAN = bankAccount.IBAN,
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

                    invoices.Add(new Invoice
                    {
                        ID = invoiceDTO.ID,
                        TotalAmount = invoiceDTO.TotalAmount,
                        InvoiceDate = invoiceDTO.InvoiceDate,
                        BankAccountID = invoiceDTO.BankAccountID,
                        FeeID = invoiceDTO.FeeID,
                    });

                }
            }

            return new BankAccount
            {
                ID = bankAccountDTO.ID,
                IBAN = bankAccountDTO.IBAN,
                PaymentMethodID = bankAccountDTO.PaymentMethodID,
                Invoices = invoices
            };
            
        }

	}
}

