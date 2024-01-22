using System;
using QArte.API.Commands.SettlementCycleCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;
using QArte.Persistance.PersistanceModels;

//SettlementCycle
//settlementCycle

namespace QArte.API.Handlers.SettlementCycleHandlers
{
    public class PostSettlementCycleHandler : IRequestHandler<PostSettlementCycleCommand, SettlementCycleDTO>
    {
        private readonly ISettlementCycleService _settlementCycleService;

        public PostSettlementCycleHandler(ISettlementCycleService settlementCycleService)
        {
            _settlementCycleService = settlementCycleService;
        }

        public async Task<SettlementCycleDTO> Handle(PostSettlementCycleCommand request, CancellationToken cancellationToken)
        {
            var order = await _settlementCycleService.PostAsync(request.settlementCycleDTO);
            return order;
        }
    }
}

