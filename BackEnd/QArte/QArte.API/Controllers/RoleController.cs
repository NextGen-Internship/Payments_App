using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.RoleQuery;
using QArte.API.Commands.RoleCommands;

namespace QArte.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RoleController : ControllerBase
	{
        private readonly IRoleService _roleService;
		private readonly IMediator _mediatR;

		public RoleController(IRoleService roleService, IMediator mediator)
		{
			_roleService = roleService;
			_mediatR = mediator;
		}

		[HttpGet("GetByID/{id}")]
		public async Task<ActionResult<RoleDTO>> GetByID(int id)
		{
			var query = new RoleGetByIDQuery(id);
			var result = await _mediatR.Send(query);
			return Ok(result);
		}

		[HttpGet]
		public async Task<ActionResult<List<RoleDTO>>> GetAll()
		{
			var query = new RoleGetAllQuery();
			var result = await _mediatR.Send(query);
			return Ok(result);
		}

		[HttpDelete("DeleteByID/{id}")]
		public async Task<ActionResult<RoleDTO>> DeleteByID(int id)
		{
			var command = new RoleDeteleCommand(id);
			var result = await _mediatR.Send(command);
			return Ok(result);
		}

		[HttpPatch("PatchByID/{id}")]
		public async Task<ActionResult<RoleDTO>> PatchByID(int id, RoleDTO obj)
		{
			var command = new RolePatchCommand(id, obj);
			var result = await _mediatR.Send(command);
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<RoleDTO>> Post(RoleDTO obj)
		{
			var command = new RolePostCommand(obj);
			var result = await _mediatR.Send(command);
			return Ok(result);
		}

	}
}

