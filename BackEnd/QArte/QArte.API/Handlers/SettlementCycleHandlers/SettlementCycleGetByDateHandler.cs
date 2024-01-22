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
    public class SettlementCycleGetByDateHandler : IRequestHandler<GetSettlementCycleByDateQuery, List<SettlementCycleDTO>>
    {
        private readonly ISettlementCycleService _settlementCycleService;

        public SettlementCycleGetByDateHandler(ISettlementCycleService settlementCycleService)
        {
            _settlementCycleService = settlementCycleService;
        }

        public async Task<List<SettlementCycleDTO>> Handle(GetSettlementCycleByDateQuery request, CancellationToken cancellationToken)
        {
            var order = await _settlementCycleService.GetSettlementCycleByDate(request.date);
            return (List<SettlementCycleDTO>)order;
        }
    }
}

