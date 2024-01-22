using System;
using MediatR;
using QArte.API.Commands.PaymentMethodCommands;
using QArte.API.Commands.SettlementCycleCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.Services;


namespace QArte.API.Handlers.SettlementCycleHandlers
{
    public class DeleteSettlementCycleHandler : IRequestHandler<DeleteSettlementCycleCommand, SettlementCycleDTO>
    {
        private readonly ISettlementCycleService _settlementCycleService;

        public DeleteSettlementCycleHandler(ISettlementCycleService settlementCycleService)
        {
            _settlementCycleService = settlementCycleService;
        }

        public async Task<SettlementCycleDTO> Handle(DeleteSettlementCycleCommand request, CancellationToken cancellationToken)
        {
            var order = await _settlementCycleService.DeleteAsync(request.Id);
            return order;
        }
    }
}

