using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance.Enums;
using QArte.Persistance;
using QArte.Persistance.PersistanceModels;
using QArte.Persistance.Helpers;

namespace QArte.Services.Services
{
    public class BankAccountService : IBankAccountService
    {

        private readonly QArteDBContext _qArteDBContext;

        public BankAccountService(QArteDBContext qArteDBContext)
        {
            this._qArteDBContext = qArteDBContext;
        }

        public async Task<bool> BankAccountExists(int id, string IBAN)
        {
            return await _qArteDBContext.BankAccounts.AnyAsync(x => x.ID == id && x.IBAN == IBAN);
        }

        async Task<BankAccountDTO> ICRUDshared<BankAccountDTO>.DeleteAsync(int id)
        {
            var bankAccount = await this._qArteDBContext.BankAccounts
                .Include(x => x.PaymentMethod)
                .Include(x => x.Invoices)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new AppException("Not found");

            this._qArteDBContext.BankAccounts.Remove(bankAccount);
            await _qArteDBContext.SaveChangesAsync();

            return bankAccount.GetDTO();
                
        }

        async Task<IEnumerable<BankAccountDTO>> ICRUDshared<BankAccountDTO>.GetAsync()
        {
            return await this._qArteDBContext.BankAccounts
                .Include(x => x.PaymentMethod)
                .Include(x => x.Invoices)
                .Select(x => new BankAccountDTO
                {
                    ID = x.ID,
                    IBAN = x.IBAN,
                    PaymentMethodID = x.PaymentMethodID,
                    Invoices = x.Invoices.Select(y => new InvoiceDTO
                    {
                        ID = y.ID,
                        TotalAmount = y.TotalAmount,
                        InvoiceDate = y.InvoiceDate,
                        FeeID = y.FeeID,
                        BankAccountID = y.BankAccountID
                    }).ToList()
                }).ToListAsync();
        }

        async Task<IEnumerable<BankAccountDTO>> IBankAccountService.GetBankAccountsByPaymentMethod(string ePaymentMethod)
        {
            Enum.TryParse(typeof(EPaymentMethods), ePaymentMethod, out var parsedPaymentMethod);

            return await _qArteDBContext.BankAccounts
                .Include(x => x.PaymentMethod)
                .Include(x => x.Invoices)
                .Where(x => x.PaymentMethod.PaymentMethods == (EPaymentMethods)parsedPaymentMethod)
                .Select(x => new BankAccountDTO
                {
                    ID = x.ID,
                    IBAN = x.IBAN,
                    PaymentMethodID = x.PaymentMethodID,
                    Invoices = x.Invoices.Select(y => new InvoiceDTO
                    {
                        ID = y.ID,
                        TotalAmount = y.TotalAmount,
                        InvoiceDate = y.InvoiceDate
                    }).ToList()
                }).ToListAsync();
        }

        async Task<BankAccountDTO> IBankAccountService.GetByIBANAsync(string IBAN)
        {
            var bankAccount = await _qArteDBContext.BankAccounts
                        .Include(x => x.PaymentMethod)
                        .Include(x => x.Invoices)
                        .FirstOrDefaultAsync(x => x.IBAN == IBAN)
                        ?? throw new AppException("String not found");

            return bankAccount.GetDTO();
        }

        async Task<BankAccountDTO> IBankAccountService.GetByIDAsync(int id)
        {
            var bankAccount = await _qArteDBContext.BankAccounts
                          .Include(x => x.PaymentMethod)
                          .Include(x => x.Invoices)
                          .FirstOrDefaultAsync(x => x.ID == id)
                          ?? throw new AppException("Not found");
            return bankAccount.GetDTO();
        }

        async Task<BankAccountDTO> ICRUDshared<BankAccountDTO>.PostAsync(BankAccountDTO obj)
        {
            _ = await BankAccountExists(obj.ID, obj.IBAN)
                == true ? throw new AppException("Not found") : 0;



            var newBankAccount = obj.GetEntity();
            await this._qArteDBContext.BankAccounts.AddAsync(newBankAccount);
            await this._qArteDBContext.SaveChangesAsync();
            return newBankAccount.GetDTO();

        }

        async Task<BankAccountDTO> IBankAccountService.AddInvoice(int BankAccID, InvoiceDTO obj)
        {
            var bankAccount = await _qArteDBContext.BankAccounts
                            .Include(x => x.PaymentMethod)
                            .Include(x => x.Invoices)
                            .FirstOrDefaultAsync(x => x.ID == BankAccID)
                        ?? throw new AppException("Not found");

            bankAccount.Invoices.Add(obj.GetEntity());
            await _qArteDBContext.SaveChangesAsync();

            return bankAccount.GetDTO();

        }

        async Task<BankAccountDTO> ICRUDshared<BankAccountDTO>.UpdateAsync(int id, BankAccountDTO obj)
        {
            _ = await BankAccountExists(obj.ID, obj.IBAN)
                == true ? throw new AppException("Not found") : 0;

            var BankAccount = await this._qArteDBContext.BankAccounts
                .Include(x => x.PaymentMethod)
                .Include(x => x.Invoices)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new AppException("Not found");

            if (obj.IBAN == null)
            {
                throw new AppException("Bad input");
            }

            BankAccount.ID = obj.ID;
            BankAccount.IBAN = obj.IBAN;
            await _qArteDBContext.SaveChangesAsync();

            return BankAccount.GetDTO();
        }

    }
}

