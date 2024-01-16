using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Queries.BankAccountQueries
{
	public class GetBankAccountByBeneficiaryNameQuery : IRequest <List<BankAccountDTO>>
    {
        public string beneficiaryName;

        public GetBankAccountByBeneficiaryNameQuery(string beneficiaryName)
		{
			this.beneficiaryName = beneficiaryName;
		}
	}
}

