using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.GalleryCommands
{
	public class UpdateGalleryCommand : IRequest<GalleryDTO>
	{
		public int Id;
		public GalleryDTO GalleryDTO;
		public UpdateGalleryCommand(int id, GalleryDTO galleryDTO)
		{
			Id = id;
			GalleryDTO = galleryDTO;
		}
	}
}

