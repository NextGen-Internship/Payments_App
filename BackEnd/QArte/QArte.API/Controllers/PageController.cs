using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.PageQueries;
using QArte.API.Commands.PageCommands;
using QArte.API.Queries.BankAccountQueries;
using QArte.API.Commands.BankAccountCommands;

namespace QArte.API.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class PageController : ControllerBase
	{
        private readonly IPageService _pageService;
        private readonly IMediator _mediatR;

        public PageController(IPageService pageService, IMediator mediator)
		{
            _pageService = pageService;
            _mediatR = mediator;
		}

        [HttpGet]
        public async Task<ActionResult<List<PageDTO>>> GetAll()
        {
            var query = new PageGetAllQuery();
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<PageDTO>> GetByID(int id)
        {
            var query = new PageGetByIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpGet("GetByUserID/{Userid}")]
        public async Task<ActionResult<List<PageDTO>>> GetByUserID(int Userid)
        {
            var query = new PageGetByUserIDQuery(Userid);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpGet("GetQRCode/{id}")]
        public async Task<ActionResult<PageDTO>> GetQRCode(int id)
        {
            var query = new QRCodeGetByID(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }


        [HttpPost("Post")]
        public async Task<ActionResult<PageDTO>> PostPage([FromBody] PageDTO obj)
        {
            var query = new PagePostCommand(obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpPatch("PatchByID/{id}")]
        public async Task<ActionResult<Page>> PatchPage(int id, [FromBody] PageDTO obj)
        {
            var query = new PagePatchCommand(id, obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult<BankAccountDTO>> DeleteBankAccount(int id)
        {
            var query = new PageDeleteCommand(id);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }
    }
}

