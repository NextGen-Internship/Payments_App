using System;
using QArte.API.Queries.BankAccountQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.BankAccountHandlers
{
	public class BankAccountGetByIDHandler : IRequestHandler<GetBankAccountByIDQuery, BankAccountDTO>
	{

        private readonly IBankAccountService _bankAccountService;
        

        public BankAccountGetByIDHandler(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public async Task<BankAccountDTO> Handle(GetBankAccountByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _bankAccountService.GetByIDAsync(request.Id);
            //var Mapped = order.GetEntity();
            return order;
        }
    }
}

