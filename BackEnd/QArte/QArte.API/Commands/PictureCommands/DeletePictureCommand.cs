using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.PictureCommands
{
	public class DeletePictureCommand : IRequest<PictureDTO>
	{
		public int Id;

        public DeletePictureCommand(int id)
        {
            Id = id;
        }
    }
}

