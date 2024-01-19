using System;
using QArte.Services.DTOs;
using MediatR;
namespace QArte.API.Commands.RoleCommands
{
	public class RolePostCommand : IRequest<RoleDTO>
	{

		public RoleDTO roleDTO;

		public RolePostCommand(RoleDTO role)
		{
			this.roleDTO = role;
		}
	}
}

