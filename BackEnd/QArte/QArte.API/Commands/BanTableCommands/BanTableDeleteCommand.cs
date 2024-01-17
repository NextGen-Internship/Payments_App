using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Commands.BanTableCommands
{
	public class BanTableDeleteCommand : IRequest<BanTableDTO>
	{
		public int id;

		public BanTableDeleteCommand(int id)
		{
			this.id = id;
		}
	}
}

