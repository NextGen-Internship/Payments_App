using System;
using QArte.API.Commands.RoleCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.RoleHandler
{
	public class RoleDeleteHandler : IRequestHandler<RoleDeteleCommand,RoleDTO>
	{
		private readonly IRoleService _roleService;

		public RoleDeleteHandler(IRoleService roleService)
		{
			_roleService = roleService;
		}

        public async Task<RoleDTO> Handle(RoleDeteleCommand request, CancellationToken cancellationToken)
        {
			var order = await _roleService.DeleteAsync(request.id);
			return order;
        }
    }
}

