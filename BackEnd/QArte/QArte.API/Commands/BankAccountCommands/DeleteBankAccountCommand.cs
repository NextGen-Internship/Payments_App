using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.BankAccountCommands
{
	public class DeleteBankAccountCommand : IRequest<BankAccountDTO>
    {
		public int Id;

		public DeleteBankAccountCommand(int id)
		{
			Id = id;
		}
	}
}

