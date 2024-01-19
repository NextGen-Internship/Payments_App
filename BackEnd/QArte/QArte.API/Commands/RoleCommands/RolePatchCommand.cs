using System;
using QArte.Services.DTOs;
using MediatR;
namespace QArte.API.Commands.RoleCommands
{
	public class RolePatchCommand : IRequest<RoleDTO>
	{
		public int id;
		public RoleDTO roleDTO;

		public RolePatchCommand(int id, RoleDTO role)
		{
			this.id = id;
			this.roleDTO = role;
		}
	}
}

