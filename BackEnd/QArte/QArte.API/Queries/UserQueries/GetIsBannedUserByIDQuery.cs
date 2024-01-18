using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.UserQueries
{
	public class GetIsBannedUserByIDQuery : IRequest<bool>
	{
		public int Id;

        public GetIsBannedUserByIDQuery(int id)
        {
            Id = id;
        }
    }
}

