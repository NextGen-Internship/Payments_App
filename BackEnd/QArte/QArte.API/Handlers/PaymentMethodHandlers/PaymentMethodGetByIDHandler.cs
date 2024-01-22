using System;
using QArte.API.Queries.PaymentMethodQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;

namespace QArte.API.Handlers.PaymentMethodHandlers
{
    public class PaymentMethodGetByIDHandler : IRequestHandler<GetPaymentMethodByIDQuery, PaymentMethodDTO>
    {
        private readonly IPaymentMethodsService _paymentMethodService;

        public PaymentMethodGetByIDHandler(IPaymentMethodsService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        public async Task<PaymentMethodDTO> Handle(GetPaymentMethodByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _paymentMethodService.GetPaymentMethodByID(request.id);
            return order;
        }
    }
}

