using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance;
using QArte.Persistance.PersistanceModels;
using QArte.Persistance.Helpers;

namespace QArte.Services.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly QArteDBContext _qArteDBContext;

        public InvoiceService(QArteDBContext qArteDBContext)
        {
            _qArteDBContext = qArteDBContext;
        }


        public async Task<IEnumerable<InvoiceDTO>> GetAsync()
        {
            return await _qArteDBContext.Invoices
                    .Select(x => new InvoiceDTO
                    {
                        ID = x.ID,
                        TotalAmount = x.TotalAmount,
                        InvoiceDate = x.InvoiceDate,
                        BankAccountID = x.BankAccountID,
                        FeeID = x.FeeID,
                    }).ToListAsync();

        }

        public List<InvoiceDTO> getAll()
        {
            return _qArteDBContext.Invoices
            .Select(x => new InvoiceDTO
            {
                ID = x.ID,
                TotalAmount = x.TotalAmount,
                InvoiceDate = x.InvoiceDate,
                BankAccountID = x.BankAccountID,
                FeeID = x.FeeID
            }).ToList();
        }

        public async Task<InvoiceDTO> GetInvoiceByBankAccountID(int id)
        {
            var result = await _qArteDBContext.Invoices
                    .Include(x => x.BankAccount)
                    .Include(x => x.Fee)
                    .FirstOrDefaultAsync(x => x.BankAccountID == id)
                    ?? throw new AppException("Not found");
            return result.GetDTO();
        }

        public async Task<InvoiceDTO> GetInvoiceByFeeID(int id)
        {
            var result = await _qArteDBContext.Invoices
                    .Include(x => x.BankAccount)
                    .Include(x => x.Fee)
                    .FirstOrDefaultAsync(x => x.FeeID == id)
                    ?? throw new AppException("Not found");
            return result.GetDTO();

        }

        public async Task<InvoiceDTO> GetInvoiceByID(int id)
        {

            var result = await _qArteDBContext.Invoices
                    .Include(x => x.BankAccount)
                    .Include(x => x.Fee)
                    .FirstOrDefaultAsync(x => x.ID == id)
                    ?? throw new AppException("Not found");
            return result.GetDTO();

        }


        public async Task<bool> InvoiceExists(int id)
        {
            return await _qArteDBContext.Invoices.AnyAsync(x => x.ID == id);
        }

        public async Task<InvoiceDTO> PostAsync(InvoiceDTO obj)
        {
            _ = await InvoiceExists(obj.ID)
                != true ? 0 : throw new AppException("Not found");


            var deletedInvoice = await InvoiceExists(obj.ID);
            
            if(!deletedInvoice)
            {
                await this._qArteDBContext.Invoices.AddAsync(obj.GetEntity());
                await this._qArteDBContext.SaveChangesAsync();
            }

            return obj;
        }

        public async Task<InvoiceDTO> UpdateAsync(int id, InvoiceDTO obj)
        {
            _ = await InvoiceExists(obj.ID)
                == true ? throw new AppException("Not found") : 0;


            var Invoice = await this._qArteDBContext.Invoices
                                    .Include(x => x.BankAccount)
                                    .Include(x => x.Fee)
                                    .FirstOrDefaultAsync(x => x.ID == id)
                                    ?? throw new AppException("Not found");


            Invoice.TotalAmount = obj.TotalAmount;
            Invoice.InvoiceDate = obj.InvoiceDate;

            await _qArteDBContext.SaveChangesAsync();
            return Invoice.GetDTO();

        }

        public async Task<InvoiceDTO> DeleteAsync(int id)
        {
            var invoice = await this._qArteDBContext.Invoices
                                    .Include(x => x.BankAccount)
                                    .Include(x => x.Fee)
                                    .FirstOrDefaultAsync(x => x.ID == id)
                                    ?? throw new AppException("Not found");
            this._qArteDBContext.Invoices.Remove(invoice);
            await _qArteDBContext.SaveChangesAsync();
            return invoice.GetDTO();
        }
    }
}

