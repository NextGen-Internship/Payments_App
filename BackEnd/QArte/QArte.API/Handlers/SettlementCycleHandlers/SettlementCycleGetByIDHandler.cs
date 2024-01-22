using System;
using QArte.API.Queries.SettlementCycleQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;

namespace QArte.API.Handlers.SettlementCycleHandlers
{
    public class SettlementCycleGetByIDHandler : IRequestHandler<GetSettlementCycleByIDQuery, SettlementCycleDTO>

    {
        private readonly ISettlementCycleService _settlementCycleService;

        public SettlementCycleGetByIDHandler(ISettlementCycleService settlementCycleService)
        {
            _settlementCycleService = settlementCycleService;
        }

        public async Task<SettlementCycleDTO> Handle(GetSettlementCycleByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _settlementCycleService.GetSettlementCycleByID(request.settlementCycleID);
            return order;
        }
    }
}

