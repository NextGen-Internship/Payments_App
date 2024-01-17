using System;
using QArte.API.Commands.GalleryCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.GalleryHandlers
{
	public class PostGalleryHandler : IRequestHandler<PostGalleryCommand, GalleryDTO>
	{

		private readonly IGalleryService _galleryService;

        public PostGalleryHandler(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public Task<GalleryDTO> Handle(PostGalleryCommand request, CancellationToken cancellationToken)
        {
            var order = _galleryService.PostAsync(request.GalleryDTO);
            return order;
        }
    }
}

