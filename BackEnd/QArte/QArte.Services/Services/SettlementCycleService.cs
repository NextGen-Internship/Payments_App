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
		public SettlementCycleService()
		{
		}

        public Task<SettlementCycleDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SettlementCycleDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SettlementCycleDTO> GetSettlementCycleByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<SettlementCycleDTO> GetSettlementCycleByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SettlementCycleDTO> GetSettlementCyclesBeforeDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<SettlementCycleDTO> PostAsync(SettlementCycleDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<SettlementCycleDTO> UpdateAsync(int id, SettlementCycleDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

