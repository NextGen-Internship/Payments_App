using System;
using QArte.Services.DTOs;
using MediatR;
namespace QArte.API.Queries.RoleQuery
{
	public class RoleGetByIDQuery : IRequest<RoleDTO>
	{
		public int id;

		public RoleGetByIDQuery(int id)
		{
			this.id = id;
		}
	}
}

