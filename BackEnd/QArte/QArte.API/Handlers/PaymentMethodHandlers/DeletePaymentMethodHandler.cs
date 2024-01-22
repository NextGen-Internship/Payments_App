using System;
using MediatR;
using QArte.API.Commands.PaymentMethodCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.Services;

namespace QArte.API.Handlers.PaymentMethodHandlers
{
    public class DeletePaymentMethodHandler : IRequestHandler<DeletePaymentMethodCommand, PaymentMethodDTO>
    {
        private readonly IPaymentMethodsService _paymentMethodService;

        public DeletePaymentMethodHandler(IPaymentMethodsService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        public async Task<PaymentMethodDTO> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var order = await _paymentMethodService.DeleteAsync(request.Id);
            return order;
        }
    }
}

