using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.UserCommands
{
	public class UpdateUsernameCommand : IRequest<UserDTO>
    {
        public int Id;
		public string UserName;
        public UpdateUsernameCommand(int id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}

