using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.Contracts
{
	public interface ISettlementCycleService :ICRUDshared<SettlementCycleDTO>
	{
		Task<SettlementCycleDTO> GetSettlementCycleByID(int id);
		Task<SettlementCycleDTO> GetSettlementCyclesBeforeDate(DateTime date);
		Task<SettlementCycleDTO> GetSettlementCycleByDate(DateTime date);
	}
}

