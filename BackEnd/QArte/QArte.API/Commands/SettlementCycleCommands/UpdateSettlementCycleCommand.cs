using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.SettlementCycleCommands
{
    public class UpdateSettlementCycleCommand : IRequest<SettlementCycleDTO>
    {

        public int Id;
        public SettlementCycleDTO settlementCycleDTO;

        public UpdateSettlementCycleCommand(int id, SettlementCycleDTO _settlementCycleDTO)
        {
            this.Id = id;
            this.settlementCycleDTO = _settlementCycleDTO;
        }
    }
}