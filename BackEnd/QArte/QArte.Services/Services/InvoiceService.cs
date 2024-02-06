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
        private readonly QArteDBContext _qArteDBContext;

        public InvoiceService(QArteDBContext qArteDBContext)
        {
            _qArteDBContext = qArteDBContext;
        }


        public async Task<IEnumerable<InvoiceDTO>> GetAsync()
        {
            return await _qArteDBContext.Invoices
                    //.Include(x => x.BankAccountID)
                    //.Include(x => x.SettlementCycleID)
                    .Include(x => x.Fees)
                    .Select(x => new InvoiceDTO
                    {
                        ID = x.ID,
                        TotalAmount = x.TotalAmount,
                        InvoiceDate = x.InvoiceDate,
                        SettlementCycleID = x.SettlementCycleID,
                        UserID = x.UserID,
                        Fees = x.Fees.Select(y => new FeeDTO
                        {
                            ID = y.ID,
                            Amount = y.Amount,
                            ExchangeRate = y.ExchangeRate,
                            Currency = y.Currency
                        }).ToList()
                    }).ToListAsync();

        }

        public List<InvoiceDTO> getAll()
        {
            return _qArteDBContext.Invoices
            //.Include(x => x.BankAccountID)
            //.Include(x => x.SettlementCycleID)
            .Include(x => x.Fees)
            .Select(x => new InvoiceDTO
            {
                ID = x.ID,
                TotalAmount = x.TotalAmount,
                InvoiceDate = x.InvoiceDate,
                SettlementCycleID = x.SettlementCycleID,
                UserID = x.UserID,
                Fees = x.Fees.Select(y => new FeeDTO
                {
                    ID = y.ID,
                    Amount = y.Amount,
                    ExchangeRate = y.ExchangeRate,
                    Currency = y.Currency
                }).ToList()
            }).ToList();
        }

        public async Task<InvoiceDTO> GetInvoiceByBankAccountID(int id)
        {
            var result = await _qArteDBContext.Invoices
                    //.Include(x => x.BankAccountID)
                    //.Include(x => x.SettlementCycleID)
                    .Include(x => x.Fees)
                    .FirstOrDefaultAsync(x => x.UserID == id)
                    ?? throw new ApplicationException("Not found");
            return result.GetDTO();
        }

        public async Task<InvoiceDTO> GetInvoiceByFeeID(int id)
        {
            List<InvoiceDTO> result = getAll();

            foreach (InvoiceDTO invoiceDTO in result)
            {
                foreach (FeeDTO fee in invoiceDTO.Fees)
                {
                    if (fee.ID == id)
                    {
                        return invoiceDTO;
                    }

                }
            }
            return new InvoiceDTO
            {
                ID = -1,
                TotalAmount = 200,
                InvoiceDate = DateTime.Today,
                SettlementCycleID = -1,
                UserID = -1,
                Fees = { }
            };

        }

        public async Task<InvoiceDTO> GetInvoiceByID(int id)
        {

            var result = await _qArteDBContext.Invoices
                    //.Include(x => x.BankAccountID)
                    //.Include(x => x.SettlementCycleID)
                    .Include(x => x.Fees)
                    .FirstOrDefaultAsync(x => x.ID == id)
                    ?? throw new ApplicationException("Not found");
            return result.GetDTO();

        }

        public async Task<InvoiceDTO> GetInvoiceBySettlementCycleID(int id)
        {
            var result = await _qArteDBContext.Invoices
                .Include(x => x.SettlementCycle)
                .Include(x => x.User)
                .Include(x => x.Fees)
                .FirstOrDefaultAsync(x => x.SettlementCycleID == id)
                ?? throw new ApplicationException("Not found");
            return result.GetDTO();
        }

        public async Task<bool> InvoiceExists(int id)
        {
            return await _qArteDBContext.Invoices.AnyAsync(x => x.ID == id);
        }

        public async Task<InvoiceDTO> PostAsync(InvoiceDTO obj)
        {
            _ = await InvoiceExists(obj.ID)
                != true ? 0 : throw new ApplicationException("Not found");

            InvoiceDTO result = null;
            var deletedInvoice = await _qArteDBContext.Invoices
                                    .Include(x => x.SettlementCycle)
                                    .Include(x => x.User)
                                    .Include(x => x.Fees)
                                    .IgnoreQueryFilters()
                                    .FirstOrDefaultAsync(x => x.ID == obj.ID);
            var newInvoice = obj.GetEntity();
            if (deletedInvoice == null)
            {
                await this._qArteDBContext.Invoices.AddAsync(newInvoice);
                await _qArteDBContext.SaveChangesAsync();
                result = newInvoice.GetDTO();
            }
            else
            {
                result = deletedInvoice.GetDTO();
            }
            return result;
        }

        public async Task<InvoiceDTO> UpdateAsync(int id, InvoiceDTO obj)
        {
            _ = await InvoiceExists(obj.ID)
                == true ? throw new ApplicationException("Not found") : 0;

            var Invoice = await this._qArteDBContext.Invoices
                                    .Include(x => x.SettlementCycle)
                                    .Include(x => x.User)
                                    .Include(x => x.Fees)
                                    .FirstOrDefaultAsync(x => x.ID == id)
                                    ?? throw new ApplicationException("Not found");

            Invoice.ID = obj.ID;
            Invoice.TotalAmount = obj.TotalAmount;
            Invoice.InvoiceDate = obj.InvoiceDate;

            await _qArteDBContext.SaveChangesAsync();
            return Invoice.GetDTO();

        }

        public async Task<InvoiceDTO> DeleteAsync(int id)
        {
            var invoice = await this._qArteDBContext.Invoices
                                    .Include(x => x.SettlementCycle)
                                    .Include(x => x.User)
                                    .Include(x => x.Fees)
                                    .FirstOrDefaultAsync(x => x.ID == id)
                                    ?? throw new ApplicationException("Not found");
            this._qArteDBContext.Invoices.Remove(invoice);
            await _qArteDBContext.SaveChangesAsync();

            return invoice.GetDTO();
        }
    }
}

