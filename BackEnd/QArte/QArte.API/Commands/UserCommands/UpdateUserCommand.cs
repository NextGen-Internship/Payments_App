using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.UserCommands
{
	public class UpdateUserCommand : IRequest<UserDTO>
	{
		public int Id;
		public UserDTO userDTO;

        public UpdateUserCommand(int id, UserDTO userDTO)
        {
            Id = id;
            this.userDTO = userDTO;
        }
    }
}

