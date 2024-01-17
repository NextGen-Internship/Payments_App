using System;
using QArte.API.Queries.BankAccountQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.BankAccountHandlers
{
	public class BankAccountGetByIBANHandler : IRequestHandler<GetBankAccountByIBANQuery, BankAccountDTO>
	{
        private readonly IBankAccountService _bankAccountService;


        public BankAccountGetByIBANHandler(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public async Task<BankAccountDTO> Handle(GetBankAccountByIBANQuery request, CancellationToken cancellationToken)
        {
            var order = await _bankAccountService.GetByIBANAsync(request.IBAN);
            return order;
        }
    }
}

