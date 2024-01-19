using System;
using QArte.API.Queries.GalleryQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.GalleryHandlers
{
	public class GalleryGetAllHandler : IRequestHandler<GetGalleryAllQuery, List<GalleryDTO>>
	{

		private readonly IGalleryService _galleryService;
        public GalleryGetAllHandler(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public async Task<List<GalleryDTO>> Handle(GetGalleryAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _galleryService.GetAsync();
            return (List<GalleryDTO>)order;
        }
    }
}

