using System;
using QArte.API.Queries.PaymentMethodQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;

namespace QArte.API.Handlers.PaymentMethodHandlers
{
    public class PaymentMethodGetAllHandler : IRequestHandler<GetPaymentMethodAllQuery, List<PaymentMethodDTO>>

    {
        private readonly IPaymentMethodsService _paymentMethodService;

        public PaymentMethodGetAllHandler(IPaymentMethodsService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        public async Task<List<PaymentMethodDTO>> Handle(GetPaymentMethodAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _paymentMethodService.GetAsync();
            return (List<PaymentMethodDTO>)order;
        }
    }
}

