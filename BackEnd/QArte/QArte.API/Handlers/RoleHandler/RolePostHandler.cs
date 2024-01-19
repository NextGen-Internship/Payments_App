using System;
using QArte.API.Commands.RoleCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.RoleHandler
{
	public class RolePostHandler : IRequestHandler<RolePostCommand,RoleDTO>
	{
        private readonly IRoleService _roleService;

        public RolePostHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RoleDTO> Handle(RolePostCommand request, CancellationToken cancellationToken)
        {
            var order = await _roleService.PostAsync(request.roleDTO);
            return order;
        }
    }
}

