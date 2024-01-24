using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Queries.BankAccountQueries
{
	public class GetBankAccountByPaymentMethodQuery : IRequest<List<BankAccountDTO>>
    {
		public string paymentMethod;

		public GetBankAccountByPaymentMethodQuery(string paymentMethod)
		{
			this.paymentMethod = paymentMethod;
        }
	}
}

