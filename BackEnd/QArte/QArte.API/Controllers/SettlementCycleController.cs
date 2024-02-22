using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.SettlementCycleQueries;
using QArte.API.Commands.SettlementCycleCommands;


namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettlementCycleController : ControllerBase
    {
        private readonly ISettlementCycleService _settlementCycle;
        private readonly IMediator _mediatR;

        //..
        public SettlementCycleController(ISettlementCycleService settlementCycle, IMediator mediator)
        {
            _settlementCycle = settlementCycle;
            _mediatR = mediator;
        }

        //..
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SettlementCycleDTO>>> GetAll()
        {
            var query = new GetSettlementCycleAllQuery();
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        //..
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<PaymentMethodDTO>> GetByID(int id)
        {
            var query = new GetSettlementCycleByIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SettlementCycleDTO>> PostSettlementCycle([FromBody] SettlementCycleDTO obj)
        {
            var query = new PostSettlementCycleCommand(obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpPatch("PatchByID/{id}")]
        public async Task<ActionResult<SettlementCycleDTO>> UpdateSettlementCycle(int id, [FromBody] SettlementCycleDTO obj)
        {
            var query = new UpdateSettlementCycleCommand(id, obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult<SettlementCycleDTO>> DeleteSettlementCycle(int id, SettlementCycleDTO obj)
        {
            var query = new DeleteSettlementCycleCommand(id, obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

    }
}