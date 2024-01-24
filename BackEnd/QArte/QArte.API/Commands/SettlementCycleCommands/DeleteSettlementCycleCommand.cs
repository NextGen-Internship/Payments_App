using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.SettlementCycleCommands
{
    public class DeleteSettlementCycleCommand : IRequest<SettlementCycleDTO>
    {
        public int Id;
        public SettlementCycleDTO settlementCycleDTO;

        public DeleteSettlementCycleCommand(int id, SettlementCycleDTO _settlementCycleDTO)
        {
            Id = id;
            settlementCycleDTO = _settlementCycleDTO;
        }
    }
}