using System;
using QArte.API.Commands.PaymentMethodCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;


namespace QArte.API.Handlers.PaymentMethodHandlers
{
    public class PostPaymentMethodHandler : IRequestHandler<PostPaymentMethodCommand, PaymentMethodDTO>
    {
        private readonly IPaymentMethodsService _paymentMethodService;

        public PostPaymentMethodHandler(IPaymentMethodsService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }
        public async Task<PaymentMethodDTO> Handle(PostPaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var order = await _paymentMethodService.PostAsync(request.PaymentMethodDTO);
            return order;
        }
    }
}

