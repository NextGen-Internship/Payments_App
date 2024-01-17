using System;
using QArte.API.Queries.RoleQuery;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.RoleHandler
{
	public class RoleGetAllHandler : IRequestHandler<RoleGetAllQuery, List<RoleDTO>>
	{
        private readonly IRoleService _roleService;

        public RoleGetAllHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<List<RoleDTO>> Handle(RoleGetAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _roleService.GetAsync();
            return (List<RoleDTO>)order;
        }
    }
}

