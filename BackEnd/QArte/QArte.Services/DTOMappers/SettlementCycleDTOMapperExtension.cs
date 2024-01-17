using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
	public static class SettlementCycleDTOMapperExtension
    {
        public static SettlementCycleDTO GetDTO(this SettlementCycle settlementCycle)
        {
            if (settlementCycle is null)
            {
                throw new ApplicationException("This settlementCycle is null");
            }


            return new SettlementCycleDTO
            {
                ID = settlementCycle.ID,
                DatePeriod = settlementCycle.DatePeriod

            };

        }

        public static SettlementCycle GetEntity(this SettlementCycleDTO settlementCycleDTO)
        {
            if (settlementCycleDTO is null)
            {
                throw new ApplicationException("This settlementCycleDTO is null");
            }


            return new SettlementCycle
            {
                ID = settlementCycleDTO.ID,
                DatePeriod = settlementCycleDTO.DatePeriod

            };

        }
    }
}

