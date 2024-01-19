using System;
using QArte.API.Queries.UserQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
    public class GetUserNameByID : IRequestHandler<GetUserNameByIDQuery, string>
    {
        private readonly IUserService _userService;

        public GetUserNameByID(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(GetUserNameByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _userService.GetUsernameByID(request.Id);
            return order;
        }
    }
}