using System;
using QArte.API.Commands.SettlementCycleCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;
using QArte.Persistance.PersistanceModels;
using QArte.API.Queries.SettlementCycleQueries;

namespace QArte.API.Handlers.SettlementCycleHandlers
{
	public class SettlementCycleGetBeforeDateHandler : IRequestHandler<GetSettlementCycleBeforeDateQuery, List<SettlementCycleDTO>>
    {
        private readonly ISettlementCycleService _settlementCycleService;

        public SettlementCycleGetBeforeDateHandler(ISettlementCycleService settlementCycleService)
        {
            _settlementCycleService = settlementCycleService;
        }

        public async Task<List<SettlementCycleDTO>> Handle(GetSettlementCycleBeforeDateQuery request, CancellationToken cancellationToken)
        {
            var order = await _settlementCycleService.GetSettlementCyclesBeforeDate(request.date);
            return (List<SettlementCycleDTO>)order;
        }
    }
}

