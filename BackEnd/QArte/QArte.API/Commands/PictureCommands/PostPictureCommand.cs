using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.PictureCommands
{
	public class PostPictureCommand : IRequest<PictureDTO>
	{
		public PictureDTO PictureDTO;

		public PostPictureCommand(PictureDTO pictureDTO)
		{
			PictureDTO = pictureDTO;
		}
	}
}

