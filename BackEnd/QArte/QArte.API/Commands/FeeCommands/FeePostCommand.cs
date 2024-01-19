using System;
using QArte.Services.DTOs;
using MediatR;

namespace QArte.API.Commands.FeeCommands
{
	public class FeePostCommand : IRequest<FeeDTO>
	{
		public FeeDTO feeDTO;

		public FeePostCommand(FeeDTO fee)
		{
			this.feeDTO = fee;
		}
	}
}

