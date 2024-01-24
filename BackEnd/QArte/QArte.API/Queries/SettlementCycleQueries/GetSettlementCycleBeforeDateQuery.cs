using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.SettlementCycleQueries
{
    public class GetSettlementCycleBeforeDateQuery : IRequest<List<SettlementCycleDTO>>
    {
        public DateTime date;
        public GetSettlementCycleBeforeDateQuery(DateTime date)
        {
            this.date = date;
        }
    }
}

