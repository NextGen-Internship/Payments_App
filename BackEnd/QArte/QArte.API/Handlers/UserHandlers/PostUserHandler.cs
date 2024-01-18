using System;
using QArte.API.Commands.UserCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.API.Queries.UserQueries;

namespace QArte.API.Handlers.UserHandlers
{
	public class PostUserHandler : IRequestHandler<PostUserCommand, UserDTO>
    {
        private readonly IUserService _userService;

        public PostUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            var order = await _userService.PostAsync(request.UserDTO);
            return order;
        }
    }
}

