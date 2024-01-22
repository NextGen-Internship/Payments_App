using System;
using QArte.API.Commands.PaymentMethodCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;

namespace QArte.API.Handlers.PaymentMethodHandlers
{
    public class UpdatePaymentMethodHandler : IRequestHandler<UpdatePaymentMethodCommand, PaymentMethodDTO>
    {
        private readonly IPaymentMethodsService paymentMethodService;

        public UpdatePaymentMethodHandler(IPaymentMethodsService _paymentMethodService)
        {
            paymentMethodService = _paymentMethodService;
        }

        public async Task<PaymentMethodDTO> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var order = await paymentMethodService.UpdateAsync(request.Id, request.paymentMethodDTO);
            return order;
        }
    }
}

