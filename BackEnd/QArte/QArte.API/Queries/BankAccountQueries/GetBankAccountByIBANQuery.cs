using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;


namespace QArte.API.Queries.BankAccountQueries
{
	public class GetBankAccountByIBANQuery : IRequest<BankAccountDTO>
	{
		public string IBAN;

        public GetBankAccountByIBANQuery(string iban)
        {
            IBAN = iban;
        }
	}
}

