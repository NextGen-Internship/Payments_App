using System;
using QArte.Services.DTOs;
using MediatR;

namespace QArte.API.Queries.BanTableQuery
{
	public class BanTableGetByIDQuery : IRequest<BanTableDTO>
	{
		public int id;

		public BanTableGetByIDQuery(int id)
		{
			this.id = id;
		}
	}
}

