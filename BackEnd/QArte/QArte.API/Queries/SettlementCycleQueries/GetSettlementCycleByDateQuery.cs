using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.SettlementCycleQueries
{
	public class GetSettlementCycleByDateQuery : IRequest<List<SettlementCycleDTO>>
    {
		public DateTime date;

        public GetSettlementCycleByDateQuery(DateTime date)
        {
            this.date = date;
        }
    }
}

