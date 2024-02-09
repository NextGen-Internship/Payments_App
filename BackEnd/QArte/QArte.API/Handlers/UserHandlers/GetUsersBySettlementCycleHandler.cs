using System;
using QArte.API.Queries.UserQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
	public class GetUsersBySettlementCycleHandler : IRequestHandler<GetUsersBySettlementCycleQuery , List<UserDTO>>
	{
        private readonly IUserService _userService;

        public GetUsersBySettlementCycleHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<UserDTO>> Handle(GetUsersBySettlementCycleQuery request, CancellationToken cancellationToken)
        {
            var order = await _userService.GetBySettlementCycle(request.SettlementCycle);
            return (List<UserDTO>)order;
        }
    }
}

