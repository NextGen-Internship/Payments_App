using System;
using QArte.Services.DTOs;
using MediatR;

namespace QArte.API.Queries.FeeQuery
{
	public class FeeGetByIDQuery : IRequest<FeeDTO>
	{
		public int id;

		public FeeGetByIDQuery(int id)
		{
			this.id = id;
		}
	}
}

