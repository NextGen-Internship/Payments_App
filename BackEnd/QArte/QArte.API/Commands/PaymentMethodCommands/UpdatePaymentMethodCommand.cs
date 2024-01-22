using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.PaymentMethodCommands
{
    public class UpdatePaymentMethodCommand : IRequest<PaymentMethodDTO>
    {
        public int Id;
        public PaymentMethodDTO paymentMethodDTO;

        public UpdatePaymentMethodCommand(int id, PaymentMethodDTO paymentMethodDTO)
        {
            this.Id = id;
            this.paymentMethodDTO = paymentMethodDTO;
        }

    }
}

