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


            return new InvoiceDTO
            {
                ID = invoice.ID,
                TotalAmount = invoice.TotalAmount,
                InvoiceDate = invoice.InvoiceDate,
                BankAccountID = invoice.BankAccountID,
                FeeID = invoice.FeeID,
            };

        }


        public static Invoice GetEntity(this InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO is null)
            {
                throw new ApplicationException("This invoiceDTO is null");
            }

            return new Invoice
            {
                ID = invoiceDTO.ID,
                TotalAmount = invoiceDTO.TotalAmount,
                InvoiceDate = invoiceDTO.InvoiceDate,
                BankAccountID = invoiceDTO.BankAccountID,
                FeeID = invoiceDTO.FeeID,
            };

        }

    }
}

