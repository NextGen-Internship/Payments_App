using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.PaymentMethodCommands
{
    public class DeletePaymentMethodCommand : IRequest<PaymentMethodDTO>
    {
        public int Id;

        public DeletePaymentMethodCommand(int id)
        {
            Id = id;
        }
    }
}



