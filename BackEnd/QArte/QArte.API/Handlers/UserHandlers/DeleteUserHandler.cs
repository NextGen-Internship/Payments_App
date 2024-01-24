using System;
using MediatR;
using QArte.API.Commands.GalleryCommands;
using QArte.API.Commands.UserCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
namespace QArte.API.Handlers.UserHandlers
{
	public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, UserDTO>
    {
        private readonly IUserService _userService;
        public DeleteUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var order = await _userService.DeleteAsync(request.Id);
            return order;
        }
    }
}

