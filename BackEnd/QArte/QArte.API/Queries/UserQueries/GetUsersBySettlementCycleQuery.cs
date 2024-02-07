using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Persistance.Enums;

namespace QArte.API.Queries.UserQueries
{
    public class GetUsersBySettlementCycleQuery : IRequest<List<UserDTO>>
    {

        public string SettlementCycle;
        public GetUsersBySettlementCycleQuery(string settlementCycle)
        {
            SettlementCycle = settlementCycle;
        }
    }
}

