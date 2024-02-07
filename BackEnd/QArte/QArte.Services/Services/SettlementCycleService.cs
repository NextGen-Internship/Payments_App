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
                        .Include(x => x.SettlementCycles)
                        .FirstOrDefaultAsync(x => x.ID == id)
                        ?? throw new ApplicationException("Not found");

            settlementCycle.ID = obj.ID;
            await _qArteDBContext.SaveChangesAsync();

            return settlementCycle.GetDTO();
        }

        public async Task<SettlementCycleDTO> DeleteAsync(int id)
        {
            var settlementCycle = await _qArteDBContext.SettlementCycles
                        .Include(x => x.SettlementCycles)
                        .FirstOrDefaultAsync(x => x.ID == id)
                        ?? throw new ApplicationException("Not found");

            _qArteDBContext.SettlementCycles.Remove(settlementCycle);
            await _qArteDBContext.SaveChangesAsync();

            return settlementCycle.GetDTO();
        }
    }
}

