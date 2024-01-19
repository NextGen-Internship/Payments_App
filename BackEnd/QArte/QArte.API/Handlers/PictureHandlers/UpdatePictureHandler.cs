using System;
using QArte.API.Commands.PictureCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.PictureHandlers
{
	public class UpdatePictureHandler : IRequestHandler<UpdatePictureCommand, PictureDTO>
	{
		private readonly IPictureService _pictureService;

        public UpdatePictureHandler(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public async Task<PictureDTO> Handle(UpdatePictureCommand request, CancellationToken cancellationToken)
        {
            var order = await _pictureService.UpdateAsync(request.Id, request.PictureDTO);
            return order;
        }
    }
}

