using System;
using MediatR;
using QArte.API.Queries.PaymentMethodQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;

namespace QArte.API.Handlers.PaymentMethodHandlers
{
    public class PaymentMethodGetByUserIDHandler : IRequestHandler<GetPaymentMethodByUserIDQuery, PaymentMethodDTO>
    {
        private readonly IPaymentMethodsService _paymentMethodService;

        public PaymentMethodGetByUserIDHandler(IPaymentMethodsService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        public async Task<PaymentMethodDTO> Handle(GetPaymentMethodByUserIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _paymentMethodService.GetPaymentMethodByUserID(request.userID);
            return order;
        }
    }
}

