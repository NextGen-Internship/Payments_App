using System;
using MediatR;
using QArte.API.Commands.GalleryCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;

namespace QArte.API.Handlers.GalleryHandlers
{
	public class DeleteGalleryHandler : IRequestHandler<DeleteGalleryCommand, GalleryDTO>
    {
        private readonly IGalleryService _galleryService;

        public DeleteGalleryHandler(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public async Task<GalleryDTO> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
        {
            var order = await _galleryService.DeleteAsync(request.Id);
            return order;
        }
    }
}

