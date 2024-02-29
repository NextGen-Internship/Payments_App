using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance;
using QArte.Persistance.Helpers;
namespace QArte.Services.Services
{
    public class SettlementCycleService : ISettlementCycleService
    {
        private readonly QArteDBContext _qArteDBContext;

        public SettlementCycleService(QArteDBContext qArteDBContext)
        {
            this._qArteDBContext = qArteDBContext;
        }


        public async Task<IEnumerable<SettlementCycleDTO>> GetAsync()
        {
            return await _qArteDBContext.SettlementCycles
                  .Select(x => new SettlementCycleDTO
                  {
                      ID = x.ID,
                      SettlementCycles = x.SettlementCycles
                  }).ToListAsync();

        }

        public async Task<SettlementCycleDTO> GetSettlementCycleByID(int id)
        {
            var result = await _qArteDBContext.SettlementCycles.FirstOrDefaultAsync(x => x.ID == id);
            return result.GetDTO();
        }

        public async Task<SettlementCycleDTO> PostAsync(SettlementCycleDTO obj)
        {
            var newSettlementCycle = obj.GetEntity();

            await _qArteDBContext.SettlementCycles.AddAsync(newSettlementCycle);
            await _qArteDBContext.SaveChangesAsync();

            return newSettlementCycle.GetDTO();

        }

        public async Task<SettlementCycleDTO> UpdateAsync(int id, SettlementCycleDTO obj)
        {
            var settlementCycle = await _qArteDBContext.SettlementCycles
                        .FirstOrDefaultAsync(x => x.ID == id)
                        ?? throw new AppException("Not found");

            settlementCycle.SettlementCycles = obj.SettlementCycles;
            await _qArteDBContext.SaveChangesAsync();

            return settlementCycle.GetDTO();
        }

        public async Task<SettlementCycleDTO> DeleteAsync(int id)
        {
            var settlementCycle = await _qArteDBContext.SettlementCycles
                        .FirstOrDefaultAsync(x => x.ID == id)
                        ?? throw new AppException("Not found");

            _qArteDBContext.SettlementCycles.Remove(settlementCycle);
            await _qArteDBContext.SaveChangesAsync();

            return settlementCycle.GetDTO();
        }
    }
}

