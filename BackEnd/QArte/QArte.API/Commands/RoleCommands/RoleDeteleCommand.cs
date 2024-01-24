using System;
using QArte.Services.DTOs;
using MediatR;
namespace QArte.API.Commands.RoleCommands
{
	public class RoleDeteleCommand : IRequest<RoleDTO>
	{
		public int id;

		public RoleDeteleCommand(int id)
		{
			this.id = id;
		}
	}
}

