using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.UserCommands
{
	public class DeleteUserCommand : IRequest<UserDTO>
    {
        public int Id;

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}

