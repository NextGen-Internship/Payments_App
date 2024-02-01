using System;
using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.FeeQuery;
using QArte.API.Commands.FeeCommands;

namespace QArte.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FeeController : ControllerBase
	{
		private readonly IFeeService _feeService;
		private readonly IMediator _mediatR;

		public FeeController(IFeeService fee, IMediator mediator)
		{
			_feeService = fee;
			_mediatR = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<FeeDTO>>> GetAll()
		{
			var query = new FeeGetAllQuery();
			var request = await _mediatR.Send(query);
			return Ok(request);
		}

		[HttpGet("GetByID/{id}")]
		public async Task<ActionResult<FeeDTO>> GetByID(int id)
		{
			var query = new FeeGetByIDQuery(id);
			var request = await _mediatR.Send(query);
			return Ok(request);
		}

        [HttpGet("GeyByCurrency/{currency}")]
        public async Task<ActionResult<IEnumerable<FeeDTO>>> GetByCurrency(string currency)
        {
            var query = new FeeGetByCurrencyQuery(currency);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

		[HttpDelete("DeleteByID/{id}")]
		public async Task<ActionResult<FeeDTO>> DeleteByID(int id)
		{
            var command = new FeeDeleteCommand(id);
            var request = await _mediatR.Send(command);
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<FeeDTO>> PostFee([FromBody] FeeDTO obj)
        {
            var command = new FeePostCommand(obj);
            var request = await _mediatR.Send(command);
            return Ok(request);
        }


        [HttpPatch("PatchByID/{id}")]
		public async Task<ActionResult<FeeDTO>> PatchFee(int id, [FromBody]FeeDTO obj)
		{
			var command = new FeePatchCommand(id, obj);
			var request = await _mediatR.Send(command);
			return Ok(request);
		}

	}
}

