using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.BankAccountCommands
{
	public class UpdateBankAccountCommand : IRequest<BankAccountDTO>
	{

		public int Id;
		public BankAccountDTO bankAccountDTO;

		public UpdateBankAccountCommand(int id,BankAccountDTO bankAccountDTO)
		{
			this.Id = id;
			this.bankAccountDTO = bankAccountDTO;
		}
	}
}

