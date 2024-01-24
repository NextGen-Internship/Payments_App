using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
namespace QArte.API.Queries.UserQueries
{
	public class GetUsersByRoleIDQuery:IRequest<List<UserDTO>>
	{
		public int Id;
		public GetUsersByRoleIDQuery(int id)
		{
			Id = id;
		}
	}
}

