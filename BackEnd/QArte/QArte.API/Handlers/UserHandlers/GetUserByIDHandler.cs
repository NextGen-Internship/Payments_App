using System;
using QArte.API.Queries.UserQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
	public class GetUserByIDHandler : IRequestHandler<GetUserByIDQuery  , UserDTO>
    {
		public readonly IUserService _userService;
        public GetUserByIDHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _userService.GetUserByID(request.Id);
            return order;
        }
    }
}

