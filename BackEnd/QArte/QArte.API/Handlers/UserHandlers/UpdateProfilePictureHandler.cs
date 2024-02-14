using System;
using System;
using QArte.API.Commands.UserCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.UserHandlers
{
	public class UpdateProfilePictureHandler : IRequestHandler<UpdateProfilePictureCommand, UserDTO>
	{
        private readonly IUserService _userService;

		public UpdateProfilePictureHandler(IUserService userService)
		{
            _userService = userService;
		}

        public async Task<UserDTO> Handle(UpdateProfilePictureCommand request, CancellationToken cancellationToken)
        {
            var order = await _userService.PostUserProfilePicture(request.id, request.formFile);
            return order;
        }
    }
}

