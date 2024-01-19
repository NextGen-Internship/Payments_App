using System;
using QArte.API.Commands.PictureCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.PictureHandlers
{
	public class DeletePictureHandler : IRequestHandler<DeletePictureCommand, PictureDTO>
	{
		private readonly IPictureService _pictureService;
        public DeletePictureHandler(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public async Task<PictureDTO> Handle(DeletePictureCommand request, CancellationToken cancellationToken)
        {
            var order = await _pictureService.DeleteAsync(request.Id);

            return order;
        }
    }
}

