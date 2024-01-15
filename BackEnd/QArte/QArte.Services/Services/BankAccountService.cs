using System;
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
                ?? throw new ApplicationException("Not found");

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
                    BeneficiaryName = x.BeneficiaryName,
                    StripeInfo = x.StripeInfo,
                    PaymentMethodID = x.PaymentMethodID,
                    Invoices = x.Invoices.Select(y => new InvoiceDTO
                    {
                        ID = y.ID,
                        TotalAmount = y.TotalAmount,
                        InvoiceDate = y.InvoiceDate
                    }).ToList()
                }).ToListAsync();
        }

        async Task<IEnumerable<BankAccountDTO>> IBankAccountService.GetBankAccountsByBeneficiaryNameAsync(string BeneficiaryName)
        {
            return await _qArteDBContext.BankAccounts
                .Include(x => x.PaymentMethod)
                .Include(x => x.Invoices)
                .Where(x=>x.BeneficiaryName.ToLower().Contains(BeneficiaryName.ToLower()))
                .Select(x => new BankAccountDTO
                {
                    ID = x.ID,
                    IBAN = x.IBAN,
                    BeneficiaryName = x.BeneficiaryName,
                    StripeInfo = x.StripeInfo,
                    PaymentMethodID = x.PaymentMethodID,
                    Invoices = x.Invoices.Select(y => new InvoiceDTO
                    {
                        ID = y.ID,
                        TotalAmount = y.TotalAmount,
                        InvoiceDate = y.InvoiceDate
                    }).ToList()
                }).ToListAsync();   
        }

        async Task<IEnumerable<BankAccountDTO>> IBankAccountService.GetBankAccountsByPaymentMethod(EPaymentMethods ePaymentMethod)
        {
            return await _qArteDBContext.BankAccounts
                .Include(x => x.PaymentMethod)
                .Include(x => x.Invoices)
                .Where(x => x.PaymentMethod.PaymentMethods == ePaymentMethod)
                .Select(x => new BankAccountDTO
                {
                    ID = x.ID,
                    IBAN = x.IBAN,
                    BeneficiaryName = x.BeneficiaryName,
                    StripeInfo = x.StripeInfo,
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
                        ?? throw new ApplicationException("String not found");

            return bankAccount.GetDTO();
        }

        async Task<BankAccountDTO> IBankAccountService.GetByIDAsync(int id)
        {
            var bankAccount = await _qArteDBContext.BankAccounts
                          .Include(x => x.PaymentMethod)
                          .Include(x => x.Invoices)
                          .FirstOrDefaultAsync(x => x.ID == id)
                          ?? throw new ApplicationException("Not found");
            return bankAccount.GetDTO();
        }

        async Task<BankAccountDTO> ICRUDshared<BankAccountDTO>.PostAsync(BankAccountDTO obj)
        {
            _ = await BankAccountExists(obj.ID, obj.IBAN)
                == true ? throw new ApplicationException("Not found") : 0;

            BankAccountDTO result = null;

            var deletedBankAccount = await _qArteDBContext.BankAccounts
                                            .Include(x => x.PaymentMethod)
                                            .Include(x => x.Invoices)
                                            .IgnoreQueryFilters()
                                            .FirstOrDefaultAsync(x => x.IBAN == obj.IBAN && x.PaymentMethodID == obj.PaymentMethodID);
            var newBankAccount = obj.GetEntity();
            if (deletedBankAccount == null)
            {
                await this._qArteDBContext.BankAccounts.AddAsync(newBankAccount);
                await _qArteDBContext.SaveChangesAsync();
                result = newBankAccount.GetDTO();
            }
            else
            {
                result = deletedBankAccount.GetDTO();

            }

            return result;
        }
        async Task<BankAccountDTO> ICRUDshared<BankAccountDTO>.UpdateAsync(int id, BankAccountDTO obj)
        {
            _ = await BankAccountExists(obj.ID, obj.IBAN)
                == true ? throw new ApplicationException("Not found") : 0;

            var BankAccount = await this._qArteDBContext.BankAccounts
                .Include(x => x.PaymentMethod)
                .Include(x => x.Invoices)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            if (obj.IBAN == null)
            {
                throw new ApplicationException("Bad input");
            }

            BankAccount.ID = obj.ID;
            BankAccount.IBAN = obj.IBAN;
            await _qArteDBContext.SaveChangesAsync();

            return BankAccount.GetDTO();
        }

    }
}

