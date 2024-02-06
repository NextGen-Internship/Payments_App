using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
    public static class InvoiceDTOMapperExtension
    {

        public static InvoiceDTO GetDTO(this Invoice invoice)
        {
            if (invoice is null)
            {
                throw new ApplicationException("This invoice is null");
            }


            List<FeeDTO> feeDTOs = new List<FeeDTO>();

            foreach (Fee fee in invoice.Fees)
            {
                feeDTOs.Add(new FeeDTO{ ID = fee.ID, Amount= fee.Amount, Currency = fee.Currency, ExchangeRate = fee.ExchangeRate});
            }

            return new InvoiceDTO
            {
                ID = invoice.ID,
                TotalAmount = invoice.TotalAmount,
                InvoiceDate = invoice.InvoiceDate,
                UserID = invoice.UserID,
                SettlementCycleID = invoice.SettlementCycleID,
                Fees = feeDTOs
            };

        }


        public static Invoice GetEntity(this InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO is null)
            {
                throw new ApplicationException("This invoiceDTO is null");
            }


            List<Fee> fees = new List<Fee>();

            foreach (FeeDTO feeDTO in invoiceDTO.Fees)
            {
                fees.Add(new Fee { ID = feeDTO.ID, Amount = feeDTO.Amount, Currency = feeDTO.Currency, ExchangeRate = feeDTO.ExchangeRate });
            }

            return new Invoice
            {
                ID = invoiceDTO.ID,
                TotalAmount = invoiceDTO.TotalAmount,
                InvoiceDate = invoiceDTO.InvoiceDate,
                UserID = invoiceDTO.UserID,
                SettlementCycleID = invoiceDTO.SettlementCycleID,
                Fees = fees
            };

        }

    }
}

