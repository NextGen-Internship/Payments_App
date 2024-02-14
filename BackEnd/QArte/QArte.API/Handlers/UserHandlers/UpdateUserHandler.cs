using System;
using QArte.API.Commands.UserCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;


namespace QArte.API.Handlers.UserHandlers
{
	public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDTO>
    {
        private readonly IUserService _userService;
        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var order = await _userService.UpdateAsync(request.Id, request.userDTO);
            return order;
        }
    }
}

