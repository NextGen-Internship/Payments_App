using System;
using QArte.API.Commands.PictureCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.PictureHandlers
{
	public class PostPictureHandler : IRequestHandler<PostPictureCommand, PictureDTO>
	{
		private readonly IPictureService _pictureService;
        public PostPictureHandler(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public Task<PictureDTO> Handle(PostPictureCommand request, CancellationToken cancellationToken)
        {
            var order = _pictureService.PostAsync(request.PictureDTO);
            return order;
        }
    }
}

