using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.BankAccountCommands
{
	public class PostBankAccountCommand : IRequest<BankAccountDTO>
	{
		public BankAccountDTO BankAccountDTO;

		public PostBankAccountCommand(BankAccountDTO bankAccountDTO) 
		{
			BankAccountDTO = bankAccountDTO;
		}
	}
}

