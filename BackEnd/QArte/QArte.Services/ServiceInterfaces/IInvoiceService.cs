using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.ServiceInterfaces
{
    public interface IInvoiceService : ICRUDshared<InvoiceDTO>
    {
        Task<InvoiceDTO> GetInvoiceByID(int id);
        Task<InvoiceDTO> GetInvoiceByBankAccountID(int id);
        Task<InvoiceDTO> GetInvoiceByFeeID(int id);
    }
}

