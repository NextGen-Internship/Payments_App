using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.BanTableQuery;
using QArte.API.Commands;

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
    }
}

