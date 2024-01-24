using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.PaymentMethodCommands
{
    public class PostPaymentMethodCommand : IRequest<PaymentMethodDTO>
    {
        public PaymentMethodDTO PaymentMethodDTO;

        public PostPaymentMethodCommand(PaymentMethodDTO paymentMethodDTO)
        {
            PaymentMethodDTO = paymentMethodDTO;
        }
    }
}

