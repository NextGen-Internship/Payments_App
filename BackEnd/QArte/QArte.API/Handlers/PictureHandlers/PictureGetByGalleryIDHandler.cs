using System;
using QArte.API.Queries.PictureQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.PictureHandlers
{
	public class PictureGetByGalleryIDHandler : IRequestHandler<GetPictureByGalleryIDQuery, List<PictureDTO>>
	{
        private readonly IPictureService _pictureService;

        public PictureGetByGalleryIDHandler(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public async Task<List<PictureDTO>> Handle(GetPictureByGalleryIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _pictureService.GetPicturesByGalleryID(request.Id);
            return (List<PictureDTO>)order;
        }
    }
}

