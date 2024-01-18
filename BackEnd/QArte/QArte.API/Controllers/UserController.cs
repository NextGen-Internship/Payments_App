using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.UserQueries;
using QArte.API.Commands.UserCommands;

namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
	{
        private readonly IUserService _userService;
        private readonly IMediator _mediatR;

        public UserController(IMediator mediatR, IUserService userService)
        {
            _mediatR = mediatR;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var query = new GetUserAllQuery();
            var request = await _mediatR.Send(query);
            return Ok(request);
        }


        [HttpGet("GetUserByID/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserByID(int id)
        {
            var query = new GetUserByIDQuery(id);
            var request = await _mediatR.Send(query);
            return Ok(request);

        }

        [HttpGet("GetEmailByID/{id}")]
        public async Task<ActionResult<string>> GetUserEmailByID(int id)
        {
            var query = new GetUserEmailByIDQuery(id);
            var request = await _mediatR.Send(query);
            return Ok(request);

        }

        [HttpGet("GetUsernameByID/{id}")]
        public async Task<ActionResult<string>> GetUserNameByID(int id)
        {
            var query = new GetUserNameByIDQuery(id);
            var request = await _mediatR.Send(query);
            return Ok(request);

        }

        [HttpGet("GetUsersByRoleID/{id}")]
        public async Task<ActionResult<string>> GetUsersByRoleID(int id)
        {
            var query = new GetUsersByRoleIDQuery(id);
            var request = await _mediatR.Send(query);
            return Ok(request);

        }

        [HttpGet("isUserBanned/{id}")]
        public async Task<ActionResult<bool>> GetIsBannedUserByID(int id)
        {
            var query = new GetIsBannedUserByIDQuery(id);
            var request = await _mediatR.Send(query);
            return Ok(request);

        }


        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser([FromBody] UserDTO obj)
        {
            var query = new PostUserCommand(obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }
    }
}

