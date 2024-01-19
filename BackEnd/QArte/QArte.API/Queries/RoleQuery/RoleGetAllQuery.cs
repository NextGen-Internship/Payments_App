using System;
using QArte.Services.DTOs;
using MediatR;
namespace QArte.API.Queries.RoleQuery
{
	public class RoleGetAllQuery : IRequest<List<RoleDTO>>
	{
		public RoleGetAllQuery()
		{
		}
	}
}

