
using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.SettlementCycleQueries
{
    public class GetSettlementCycleByIDQuery : IRequest<SettlementCycleDTO>
    {
        public int settlementCycleID;

        public GetSettlementCycleByIDQuery(int _settlementCycleID)
        {
            settlementCycleID = _settlementCycleID;
        }

    }
}