using System;
using MediatR;
using QArte.Services.DTOs;
namespace QArte.API.Queries.PageQueries
{
	public class PageGetAllQuery : IRequest<List<PageDTO>>
	{
		public PageGetAllQuery()
		{
		}
	}
}

