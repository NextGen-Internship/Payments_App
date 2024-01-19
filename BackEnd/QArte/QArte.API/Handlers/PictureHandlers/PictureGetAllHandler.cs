using System;
using QArte.API.Queries.PictureQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.PictureHandlers
{
    public class PictureGetAllHandler : IRequestHandler<GetPictureAllQuery, List<PictureDTO>>
    {
        private readonly IPictureService _pictureService;

        public PictureGetAllHandler(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public async Task<List<PictureDTO>> Handle(GetPictureAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _pictureService.GetAsync();
            return (List<PictureDTO>)order;
        }
    }
}
