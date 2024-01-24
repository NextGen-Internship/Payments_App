using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
	public static class PaymentMethodDTOMapperExtension
    {

        public static PaymentMethodDTO GetDTO(this PaymentMethod paymentMethod)
        {
            if (paymentMethod is null)
            {
                throw new ApplicationException("This paymentMethod is null");
            }
            
            //List<BankAccountDTO> bankAccountDTOs = new List<BankAccountDTO>();

            //foreach (BankAccount bankAccount in paymentMethod.BankAccounts)
            //{
            //    List<InvoiceDTO> invoiceDTOs = new List<InvoiceDTO>();
            //    foreach (Invoice invoice in bankAccount.Invoices)
            //    {
            //        List<FeeDTO> feeDTOs = new List<FeeDTO>();
            //        foreach (Fee fee in invoice.Fees)
            //        {
            //            feeDTOs.Add(new FeeDTO { ID = fee.ID, Amount = fee.Amount, Currency = fee.Currency, ExchangeRate = fee.ExchangeRate });
            //        }
            //        invoiceDTOs.Add(new InvoiceDTO
            //        {
            //            ID = invoice.ID,
            //            TotalAmount = invoice.TotalAmount,
            //            InvoiceDate = invoice.InvoiceDate,
            //            BankAccoundID = invoice.BankAccountID,
            //            SettlementCycleID = invoice.SettlementCycleID,
            //            Fees = feeDTOs
            //        });
            //    }
            //    bankAccountDTOs.Add(new BankAccountDTO { ID = paymentMethod.ID, IBAN = bankAccount.IBAN , BeneficiaryName = bankAccount.BeneficiaryName, StripeInfo = bankAccount.StripeInfo, PaymentMethodID = bankAccount.PaymentMethodID, Invoices = invoiceDTOs});
            //}

            return new PaymentMethodDTO
            {
                ID = paymentMethod.ID,
                paymentName = paymentMethod.PaymentMethods,
                //BankAccounts = bankAccountDTOs
            };

        }

        public static PaymentMethod GetEnity(this PaymentMethodDTO paymentMethodDTO)
        {
            if (paymentMethodDTO is null)
            {
                throw new ApplicationException("This paymentMethod is null");
            }

            //List<BankAccount> bankAccounts = new List<BankAccount>();

            //foreach (BankAccountDTO bankAccountDTO in paymentMethodDTO.BankAccounts)
            //{
            //    List<Invoice> invoices = new List<Invoice>();
            //    foreach (InvoiceDTO invoiceDTO in bankAccountDTO.Invoices)
            //    {
            //        List<Fee> fees = new List<Fee>();
            //        foreach (FeeDTO feeDTO in invoiceDTO.Fees)
            //        {
            //            fees.Add(new Fee { ID = feeDTO.ID, Amount = feeDTO.Amount, Currency = feeDTO.Currency, ExchangeRate = feeDTO.ExchangeRate });
            //        }
            //        invoices.Add(new Invoice
            //        {
            //            ID = invoiceDTO.ID,
            //            TotalAmount = invoiceDTO.TotalAmount,
            //            InvoiceDate = invoiceDTO.InvoiceDate,
            //            BankAccountID = invoiceDTO.BankAccoundID,
            //            SettlementCycleID = invoiceDTO.SettlementCycleID,
            //            Fees = fees
            //        });
            //    }
            //    bankAccounts.Add(new BankAccount { ID = paymentMethodDTO.ID, IBAN = bankAccountDTO.IBAN, BeneficiaryName = bankAccountDTO.BeneficiaryName, StripeInfo = bankAccountDTO.StripeInfo, PaymentMethodID = bankAccountDTO.PaymentMethodID, Invoices = invoices });
            //}

            return new PaymentMethod
            {
                ID = paymentMethodDTO.ID,
                PaymentMethods = paymentMethodDTO.paymentName,
                //BankAccounts = bankAccounts
            };

        }



    }
}

