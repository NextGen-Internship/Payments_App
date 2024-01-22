using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.SettlementCycleCommands
{
    public class PostSettlementCycleCommand : IRequest<SettlementCycleDTO>
    {
        public SettlementCycleDTO settlementCycleDTO;

        public PostSettlementCycleCommand(SettlementCycleDTO _settlementCycleDTO)
        {
            settlementCycleDTO = _settlementCycleDTO;
        }
    }
}