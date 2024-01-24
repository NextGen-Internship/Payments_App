using System;
using QArte.API.Commands.SettlementCycleCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;

namespace QArte.API.Handlers.SettlementCycleHandlers
{
    public class UpdateSettlementCycleHandler : IRequestHandler<UpdateSettlementCycleCommand, SettlementCycleDTO>
    {
        private readonly ISettlementCycleService settlementCycleService;

        public UpdateSettlementCycleHandler(ISettlementCycleService _settlementCycleService)
        {
            settlementCycleService = _settlementCycleService;
        }

        public async Task<SettlementCycleDTO> Handle(UpdateSettlementCycleCommand request, CancellationToken cancellationToken)
        {
            var order = await settlementCycleService.UpdateAsync(request.Id, request.settlementCycleDTO);
            return order;
        }
    }
}

