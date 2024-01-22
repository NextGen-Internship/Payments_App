using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance.Enums;
using QArte.Persistance;
using Microsoft.VisualBasic;
using QArte.Persistance.PersistanceModels;

namespace QArte.Services.Services
{
	public class InvoiceService : IInvoiceService
	{
		public InvoiceService()
		{
		}

        public Task<InvoiceDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoiceDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> GetInvoiceByBankAccountID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> GetInvoiceByFeeID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> GetInvoiceByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> GetInvoiceBySettlementCycleID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> PostAsync(InvoiceDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> UpdateAsync(int id, InvoiceDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

