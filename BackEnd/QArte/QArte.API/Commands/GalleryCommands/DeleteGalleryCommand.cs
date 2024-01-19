using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
namespace QArte.API.Commands.GalleryCommands
{
	public class DeleteGalleryCommand : IRequest<GalleryDTO>
	{
		public int Id;

        public DeleteGalleryCommand(int id)
        {
            Id = id;
        }
    }
}

