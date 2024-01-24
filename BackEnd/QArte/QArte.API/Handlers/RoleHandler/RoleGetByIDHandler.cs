using System;
using QArte.API.Queries.RoleQuery;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.RoleHandler
{
	public class RoleGetByIDHandler : IRequestHandler<RoleGetByIDQuery, RoleDTO>
	{
        private readonly IRoleService _roleService;

        public RoleGetByIDHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RoleDTO> Handle(RoleGetByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _roleService.GetRoleByID(request.id);
            return order;
        }
    }
}

