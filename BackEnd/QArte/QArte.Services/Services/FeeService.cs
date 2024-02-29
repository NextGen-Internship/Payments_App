using QArte.Services.DTOs;
using QArte.Persistance;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Services.DTOMappers;
using QArte.Persistance.Helpers;

namespace QArte.Services.Services
{
    public class FeeService : IFeeService
    {
        private readonly QArteDBContext _qArteDBContext;


        public async Task<bool> FeeExists(int id)
        {
            return await _qArteDBContext.Fees.AnyAsync(x => x.ID == id);
        }

        public FeeService(QArteDBContext qArteDBContext)
        {
            _qArteDBContext = qArteDBContext;
        }

        public async Task<FeeDTO> GetFeeByID(int id)
        {

            var fee = await _qArteDBContext.Fees
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new AppException("Not found");
            return fee.GetDTO();
        }

        public async Task<IEnumerable<FeeDTO>> GetFeesByCurrency(string currency)
        {
            return await this._qArteDBContext.Fees
                .Where(x=>x.Currency.ToLower()==currency.ToLower())
                .Select(x => new FeeDTO
                {
                    ID = x.ID,
                    Currency = x.Currency,
                    Amount = x.Amount,
                    ExchangeRate = x.ExchangeRate
                }).ToListAsync();
        }

        public async Task<FeeDTO> DeleteAsync(int id)
        {

            var fee = await this._qArteDBContext.Fees
                    .FirstOrDefaultAsync(x => x.ID == id)
                    ?? throw new AppException("Not found");

            this._qArteDBContext.Fees.Remove(fee);
            await _qArteDBContext.SaveChangesAsync();

            return fee.GetDTO();
        }

        public async Task<IEnumerable<FeeDTO>> GetAsync()
        {
            return await this._qArteDBContext.Fees
                .Select(x => new FeeDTO
                {
                    ID = x.ID,
                    Currency = x.Currency,
                    Amount = x.Amount,
                    ExchangeRate = x.ExchangeRate
                }).ToListAsync();
        }

        public async Task<FeeDTO> UpdateAsync(int id, FeeDTO obj)
        {


            var fee = await this._qArteDBContext.Fees
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new AppException("Not found");

            if (obj.ID == null)
            {
                throw new AppException("Bad input");
            }

            fee.ID = obj.ID;
            fee.Currency = obj.Currency;
            fee.Amount = obj.Amount;
            fee.ExchangeRate = obj.ExchangeRate;
            await _qArteDBContext.SaveChangesAsync();

            return fee.GetDTO();
        }

        public async Task<FeeDTO> PostAsync(FeeDTO obj)
        {
            _ = await FeeExists(obj.ID)
                == true ? throw new AppException("Not found") : 0;

            FeeDTO result = null;

            var deletedBankAccount = await _qArteDBContext.Fees
                                            .IgnoreQueryFilters()
                                            .FirstOrDefaultAsync(x => x.ID==obj.ID);
            var newFee = obj.GetEntity();
            if (deletedBankAccount == null)
            {
                await this._qArteDBContext.Fees.AddAsync(newFee);
                await _qArteDBContext.SaveChangesAsync();
                result = newFee.GetDTO();
            }
            else
            {
                result = deletedBankAccount.GetDTO();

            }

            return result;
        }
    }
}