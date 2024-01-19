using System;
using MediatR;
using QArte.Services.DTOs;
namespace QArte.API.Queries.PageQueries
{
	public class PageGetByUserIDQuery : IRequest<List<PageDTO>>
	{
		public int id;

		public PageGetByUserIDQuery(int id)
		{
			this.id = id;
		}
	}
}

