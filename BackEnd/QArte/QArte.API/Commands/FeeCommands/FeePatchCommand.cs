using System;
using QArte.Services.DTOs;
using MediatR;

namespace QArte.API.Commands.FeeCommands
{
	public class FeePatchCommand : IRequest<FeeDTO>
	{
		public int id;
		public FeeDTO feeDTO;
		public FeePatchCommand(int id, FeeDTO fee)
		{
			this.id = id;
			this.feeDTO = fee;
		}
	}
}

