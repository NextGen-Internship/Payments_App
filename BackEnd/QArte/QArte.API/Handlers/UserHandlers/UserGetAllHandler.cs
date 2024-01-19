using System;
using QArte.API.Queries.UserQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
	public class UserGetAllHandler : IRequestHandler <GetUserAllQuery, List<UserDTO>>
	{
		private readonly IUserService _userService;
        public UserGetAllHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<UserDTO>> Handle(GetUserAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _userService.GetAsync();
            return (List<UserDTO>)order;
        }
    }
}

