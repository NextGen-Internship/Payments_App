using System;
using QArte.Services.DTOs;
using MediatR;

namespace QArte.API.Commands.FeeCommands
{
	public class FeeDeleteCommand : IRequest<FeeDTO>
	{
		public int id;

		public FeeDeleteCommand(int id)
		{
			this.id = id;
		}
	}
}

