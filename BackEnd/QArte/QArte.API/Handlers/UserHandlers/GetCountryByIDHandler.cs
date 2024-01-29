using System;
using QArte.API.Queries.UserQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
    public class GetCountryByIDHandler : IRequestHandler<GetCountryByIDQuery, string>
    {
        private readonly IUserService _userService;

        public GetCountryByIDHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(GetCountryByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _userService.GetCountryByID(request.Id);
            return order;
        }
    }
}

