using System;
using MediatR;
using QArte.API.Commands.BankAccountCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;

namespace QArte.API.Handlers.BankAccountHandlers
{
	public class DeleteBankAccountCommandHandler : IRequestHandler<DeleteBankAccountCommand, BankAccountDTO>
    {
        private readonly IBankAccountService _bankAccountService;

        public DeleteBankAccountCommandHandler(IBankAccountService bankAccountService)
		{
            _bankAccountService = bankAccountService;
        }

        public async Task<BankAccountDTO> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            var order = await _bankAccountService.DeleteAsync(request.Id);
            return order;
        }
    }
}

