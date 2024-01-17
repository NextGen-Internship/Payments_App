using System;
using QArte.Services.DTOs;
using MediatR;

namespace QArte.API.Queries.BanTableQuery {

	public class BanTableGetAllQuery : IRequest<List<BanTableDTO>>
	{
		public BanTableGetAllQuery()
		{
		}
	}
}

