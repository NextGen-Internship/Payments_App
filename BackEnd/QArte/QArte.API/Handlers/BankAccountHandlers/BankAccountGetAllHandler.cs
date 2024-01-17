using System;
using QArte.API.Queries.BankAccountQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.BankAccountHandlers
{
    public class BankAccountGetAllHandler : IRequestHandler<GetBankAccountAllQuery, List<BankAccountDTO>>

    {
        private readonly IBankAccountService _bankAccountService;


        public BankAccountGetAllHandler(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public async Task<List<BankAccountDTO>> Handle(GetBankAccountAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _bankAccountService.GetAsync();
            //var Mapped = order.GetEntity();
            return (List<BankAccountDTO>)order;
        }
    }
}

