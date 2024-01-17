using System;
using QArte.API.Commands.BankAccountCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.BankAccountHandlers
{
	public class PostBankAccountHandler : IRequestHandler<PostBankAccountCommand, BankAccountDTO>
	{
        private readonly IBankAccountService _bankAccountService;
		public PostBankAccountHandler(IBankAccountService bankAccountService)
		{
            _bankAccountService = bankAccountService;
		}

        public Task<BankAccountDTO> Handle(PostBankAccountCommand request, CancellationToken cancellationToken)
        {
            var order = _bankAccountService.PostAsync(request.BankAccountDTO);
            return order;
        }
    }
}

