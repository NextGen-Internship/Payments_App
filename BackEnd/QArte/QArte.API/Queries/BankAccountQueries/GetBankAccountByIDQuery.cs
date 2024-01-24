using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.BankAccountQueries
{
	public class GetBankAccountByIDQuery:IRequest<BankAccountDTO>
	{
		public int Id;

		public GetBankAccountByIDQuery(int id)
		{
			Id = id;
		}
	}
}

