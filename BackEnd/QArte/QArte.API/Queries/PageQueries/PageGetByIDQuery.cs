using System;
using MediatR;
using QArte.Services.DTOs;
namespace QArte.API.Queries.PageQueries
{
	public class PageGetByIDQuery : IRequest<PageDTO>
    {
		public int id;
		public PageGetByIDQuery(int id)
		{
			this.id = id;
		}
	}
}

