using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Commands.BanTableCommands
{
	public class BanTablePatchCommand : IRequest<BanTableDTO>
	{
		public int id;
		public BanTableDTO BankAccountDTO;

		public BanTablePatchCommand(int id, BanTableDTO ban)
		{
			this.id = id;
			this.BankAccountDTO = ban;
		}
	}
}

