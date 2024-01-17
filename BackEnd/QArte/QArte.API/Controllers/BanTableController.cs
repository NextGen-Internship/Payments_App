using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.BanTableQuery;
using QArte.API.Commands.BanTableCommands;

namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanTableController : ControllerBase
    {

        private readonly IBanTableService _banTableService;
        private readonly IMediator _mediatR;

        public BanTableController (IBanTableService banTableService, IMediator mediator)
        {
            _banTableService = banTableService;
            _mediatR = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BanTableDTO>>> GetAll()
        {
            var query = new BanTableGetAllQuery();
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpGet("GetByID{id}")]
        public async Task<ActionResult<BanTableDTO>> GetByID(int id)
        {
            var query = new BanTableGetByIDQuery(id);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<BanTableDTO>> PostBanTable([FromBody]BanTableDTO obj)
        {
            var command = new BanTablePostCommand(obj);
            var request = await _mediatR.Send(command);
            return Ok(request);
        }

        [HttpPatch("PatchByID/{id}")]
        public async Task<ActionResult<BanTableDTO>> PatchBanTable(int id,[FromBody] BanTableDTO obj)
        {
            var command = new BanTablePatchCommand(id,obj);
            var request = await _mediatR.Send(command);
            return Ok(request);
        }

        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult<BanTableDTO>> DeletehBanTable(int id)
        {
            var command = new BanTableDeleteCommand(id);
            var request = await _mediatR.Send(command);
            return Ok(request);
        }
    }

}

