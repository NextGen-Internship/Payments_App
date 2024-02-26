using System;
using QArte.API.Commands.UserCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
	public class UpdateUsernameHandler : IRequestHandler<UpdateUsernameCommand, UserDTO>
    {
        private readonly IUserService _userService;
        public UpdateUsernameHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO> Handle(UpdateUsernameCommand request, CancellationToken cancellationToken)
        {
            var order = await _userService.PatchUsername(request.Id, request.UserName);
            return order;
        }
    }
}

