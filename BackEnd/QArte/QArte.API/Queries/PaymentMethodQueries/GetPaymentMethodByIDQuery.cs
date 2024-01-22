using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Queries.PaymentMethodQueries
{
    public class GetPaymentMethodByIDQuery : IRequest<PaymentMethodDTO>
    {
        public int id;

        public GetPaymentMethodByIDQuery(int _id)
        {
            id = _id;
        }
    }
}

