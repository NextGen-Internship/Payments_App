using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.GalleryCommands
{
	public class PostGalleryCommand : IRequest<GalleryDTO>
	{
		public GalleryDTO GalleryDTO;

        public PostGalleryCommand(GalleryDTO galleryDTO)
        {
            GalleryDTO = galleryDTO;
        }
    }
}

