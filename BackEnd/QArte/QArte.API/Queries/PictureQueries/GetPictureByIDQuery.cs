using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.PictureQueries
{
	public class GetPictureByIDQuery : IRequest<PictureDTO>
	{
		public int Id;

		public GetPictureByIDQuery(int id)
		{
			Id = id;
		}
	}
}

