using System;
using QArte.API.Queries.PictureQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.PictureHandlers
{
	public class PictureGetByIDHandler : IRequestHandler<GetPictureByIDQuery, PictureDTO>
	{
		private readonly IPictureService _pictureService;

		public PictureGetByIDHandler(IPictureService pictureService)
		{
			_pictureService = pictureService;
		}

        public async Task<PictureDTO> Handle(GetPictureByIDQuery request, CancellationToken cancellationToken)
        {
			var order = await _pictureService.GetPictureByID(request.Id);
			return order;
        }
    }
}

