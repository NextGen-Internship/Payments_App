using System;
using QArte.API.Queries.UserQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
	public class GetUsersByRoleIDHandler : IRequestHandler<GetUsersByRoleIDQuery, List<UserDTO>>
	{
		private readonly IUserService _userService;
        public GetUsersByRoleIDHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<UserDTO>> Handle(GetUsersByRoleIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _userService.GetUsersByRoleID(request.Id);
            return (List<UserDTO>)order;
        }
    }
}

