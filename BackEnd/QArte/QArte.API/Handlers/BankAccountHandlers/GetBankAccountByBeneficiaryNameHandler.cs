using System;
using MediatR;
using QArte.API.Queries.BankAccountQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.Services;

namespace QArte.API.Handlers.BankAccountHandlers
{
	public class GetBankAccountByBeneficiaryNameHandler : IRequestHandler<GetBankAccountByBeneficiaryNameQuery, List<BankAccountDTO>>
    {
        private readonly IBankAccountService _bankAccountService;
        public GetBankAccountByBeneficiaryNameHandler(IBankAccountService bankAccountService)
		{
            _bankAccountService = bankAccountService;
        }

        public async Task<List<BankAccountDTO>> Handle(GetBankAccountByBeneficiaryNameQuery request, CancellationToken cancellationToken)
        {
            var order = await _bankAccountService.GetBankAccountsByBeneficiaryNameAsync(request.beneficiaryName);

            return (List<BankAccountDTO>)order;
        }
    }
}

