using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.UserQueries
{
	public class GetUserEmailByIDQuery : IRequest <string>
	{
		public int Id;
		public GetUserEmailByIDQuery(int id)
		{
			Id = id;
		}
	}
}

