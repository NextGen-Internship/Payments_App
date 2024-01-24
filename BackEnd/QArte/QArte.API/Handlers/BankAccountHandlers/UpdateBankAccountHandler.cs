using System;
using QArte.API.Commands.BankAccountCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.BankAccountHandlers
{
	public class UpdateBankAccountHandler:IRequestHandler<UpdateBankAccountCommand,BankAccountDTO>
	{

        private readonly IBankAccountService _bankAccountService;

		public UpdateBankAccountHandler(IBankAccountService bankAccountService)
		{
            _bankAccountService = bankAccountService;
		}

        public async Task<BankAccountDTO> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var order = await _bankAccountService.UpdateAsync(request.Id, request.bankAccountDTO);
            return order;
        }
    }
}

