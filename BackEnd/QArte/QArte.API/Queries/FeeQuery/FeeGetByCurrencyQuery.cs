using System;
using QArte.Services.DTOs;
using MediatR;


namespace QArte.API.Queries.FeeQuery
{
	public class FeeGetByCurrencyQuery : IRequest<List<FeeDTO>>
	{
		public string currency;

		public FeeGetByCurrencyQuery(string currency)
		{
			this.currency = currency;
		}
	}
}

