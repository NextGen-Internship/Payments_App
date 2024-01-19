using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.PictureCommands
{
	public class UpdatePictureCommand : IRequest<PictureDTO>
	{
		public int Id;
		public PictureDTO PictureDTO;

		public UpdatePictureCommand(int id ,PictureDTO pictureDTO)
		{
			Id = id;
			PictureDTO = pictureDTO;
		}
	}
}

