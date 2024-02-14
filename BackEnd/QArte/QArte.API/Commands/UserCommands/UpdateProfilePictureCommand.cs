using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.UserCommands
{
	public class UpdateProfilePictureCommand : IRequest<UserDTO>
	{
		public int id;
		public IFormFile formFile;

		public UpdateProfilePictureCommand(int id, IFormFile formFile)
		{
			this.id = id;
			this.formFile = formFile;
		}
	}
}

