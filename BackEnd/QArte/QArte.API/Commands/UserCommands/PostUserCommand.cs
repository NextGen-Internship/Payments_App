using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.UserCommands
{
	public class PostUserCommand : IRequest<UserDTO>
    {
		public UserDTO UserDTO;
		public PostUserCommand(UserDTO userDTO)
		{
			UserDTO = userDTO;
		}
	}
}

