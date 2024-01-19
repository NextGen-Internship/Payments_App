using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;


namespace QArte.API.Queries.GalleryQueries
{
	public class GetGalleryByIDQuery : IRequest<GalleryDTO>
	{
		public int Id;

        public GetGalleryByIDQuery(int id)
        {
            Id = id;
        }
    }
}

