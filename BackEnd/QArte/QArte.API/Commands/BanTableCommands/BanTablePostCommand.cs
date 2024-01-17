using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Commands.BanTableCommands
{
	public class BanTablePostCommand : IRequest<BanTableDTO>
	{
		public BanTableDTO banTable;

		public BanTablePostCommand(BanTableDTO banTable)
		{
			this.banTable = banTable;
		}
	}
}

