using System;
using QArte.Services.DTOs;
using MediatR;

namespace QArte.API.Queries.FeeQuery
{
	public class FeeGetAllQuery : IRequest<List<FeeDTO>>
	{
		public FeeGetAllQuery()
		{
		}
	}
}

