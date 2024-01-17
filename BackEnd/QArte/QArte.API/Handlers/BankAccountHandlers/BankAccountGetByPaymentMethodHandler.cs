using System;
using MediatR;
using QArte.API.Queries.BankAccountQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.Services;

namespace QArte.API.Handlers.BankAccountHandlers
{
	public class BankAccountGetByPaymentMethodHandler : IRequestHandler<GetBankAccountByPaymentMethodQuery, List<BankAccountDTO>>
    {

        private readonly IBankAccountService _bankAccountService;

        public BankAccountGetByPaymentMethodHandler(IBankAccountService bankAccountService)
		{
            _bankAccountService = bankAccountService;
        }

        public async Task<List<BankAccountDTO>> Handle(GetBankAccountByPaymentMethodQuery request, CancellationToken cancellationToken)
        {
            var order = await _bankAccountService.GetBankAccountsByPaymentMethod(request.paymentMethod);

            return (List<BankAccountDTO>)order;
        }
    }
}

