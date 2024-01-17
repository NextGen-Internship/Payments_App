using System;
using QArte.API.Commands.RoleCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.RoleHandler
{
	public class RolePatchHandler : IRequestHandler<RolePatchCommand,RoleDTO>
	{
        private readonly IRoleService _roleService;

        public RolePatchHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RoleDTO> Handle(RolePatchCommand request, CancellationToken cancellationToken)
        {
            var order = await _roleService.UpdateAsync(request.id,request.roleDTO);
            return order;
        }
    }
}

