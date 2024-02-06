using System;
using QArte.API.Queries.UserQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
    public class GetStripeAccountByIDHandler : IRequestHandler<GetStripeAccountByIDQuery, string>
    {
        private readonly IUserService _userService;

        public GetStripeAccountByIDHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(GetStripeAccountByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _userService.GetStripeAccountByID(request.Id);
            return order;
        }
    }
}
