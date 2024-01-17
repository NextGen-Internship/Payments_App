using System;
using QArte.API.Commands.GalleryCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.GalleryHandlers
{
	public class UpdateGalleryHandler : IRequestHandler<UpdateGalleryCommand, GalleryDTO>
	{
		private readonly IGalleryService _galleryService;
        public UpdateGalleryHandler(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public async Task<GalleryDTO> Handle(UpdateGalleryCommand request, CancellationToken cancellationToken)
        {
            var order = await _galleryService.UpdateAsync(request.Id, request.GalleryDTO);
            return order;
        }
    }
}

