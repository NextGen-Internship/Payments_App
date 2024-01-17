using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;


namespace QArte.API.Queries.BankAccountQueries
{
	public class GetBankAccountAllQuery:IRequest<List<BankAccountDTO>>
	{
		public GetBankAccountAllQuery()
		{

		}
	}
}

