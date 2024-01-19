using System;
using QArte.API.Queries.UserQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
	public class GetIsBannedByIDHandler : IRequestHandler<GetIsBannedUserByIDQuery, bool>
	{
        private readonly IUserService _userService;
        public GetIsBannedByIDHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(GetIsBannedUserByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _userService.isBanned(request.Id);
            return order;
        }
    }
}

