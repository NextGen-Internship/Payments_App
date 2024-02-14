using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.PictureQueries;
using QArte.API.Commands.PictureCommands;

namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PictureController : ControllerBase
    {
        private readonly IPictureService _pictureService;
        private readonly IMediator _mediatR;

        public PictureController(IPictureService pictureService, IMediator mediatR)
        {
            _pictureService = pictureService;
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PictureDTO>>> GetAll()
        {
            var query = new GetPictureAllQuery();
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<PictureDTO>> GetByID(int id)
        {
            var query = new GetPictureByIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpGet("GetByGalleryID/{id}")]
        public async Task<ActionResult<IEnumerable<PictureDTO>>> GetByGalleryID(int id)
        {
            var query = new GetPictureByGalleryIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpPost("Post")]
        public async Task<ActionResult<PictureDTO>> PostPicture([FromForm] PictureDTO obj)
        {

            var query = new PostPictureCommand(obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpPatch("PathByID/{id}")]
        public async Task<ActionResult<PictureDTO>> UpdatePicture(int id, [FromBody] PictureDTO obj)
        {
            var query = new UpdatePictureCommand(id, obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult<PictureDTO>> DeleteBankAccount(int id)
        {
            var query = new DeletePictureCommand(id);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

    }


}