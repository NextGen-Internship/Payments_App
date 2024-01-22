using System;
using QArte.API.Queries.SettlementCycleQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;
using QArte.API.Queries.PaymentMethodQueries;

namespace QArte.API.Handlers.SettlementCycleHandlers
{
    public class SettlementCycleGetAllHandler : IRequestHandler<GetSettlementCycleAllQuery, List<SettlementCycleDTO>>

    {
        private readonly ISettlementCycleService _settlementCycleService;

        public SettlementCycleGetAllHandler(ISettlementCycleService settlementCycleService)
        {
            _settlementCycleService = settlementCycleService;
        }

        public async Task<List<SettlementCycleDTO>> Handle(GetSettlementCycleAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _settlementCycleService.GetAsync();
            return (List<SettlementCycleDTO>)order;
        }
    }
}

