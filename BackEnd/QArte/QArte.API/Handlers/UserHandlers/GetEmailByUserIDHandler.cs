using System;
using QArte.API.Queries.UserQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
	public class GetEmailByUserIDHandler : IRequestHandler<GetUserEmailByIDQuery, string>
	{
		private readonly IUserService _userService;

        public GetEmailByUserIDHandler(IUserService userService)
        {
            _userService = userService;
        }

    public async Task<string> Handle(GetUserEmailByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _userService.GetEmailByID(request.Id);
            return order;
        }
    }
}

