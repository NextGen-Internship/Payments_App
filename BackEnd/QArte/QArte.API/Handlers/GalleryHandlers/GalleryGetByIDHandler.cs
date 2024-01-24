using System;
using QArte.API.Queries.GalleryQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.GalleryHandlers
{
    public class GalleryGetByIDHandler : IRequestHandler<GetGalleryByIDQuery, GalleryDTO>
    {

        private readonly IGalleryService _galleryService;

        public GalleryGetByIDHandler(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public async Task<GalleryDTO> Handle(GetGalleryByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _galleryService.GetGalleryByID(request.Id);
            return order;
        }
    }
}

