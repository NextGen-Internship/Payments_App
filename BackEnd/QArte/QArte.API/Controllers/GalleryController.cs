using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.GalleryQueries;
using QArte.API.Commands.GalleryCommands;


namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GalleryController : ControllerBase
	{
        private readonly IGalleryService _galleryService;
        private readonly IMediator _mediatR;

        public GalleryController(IGalleryService galleryService, IMediator mediatR)
        {
            _galleryService = galleryService;
            _mediatR = mediatR;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GalleryDTO>>> GetAll()
        {
            var query = new GetGalleryAllQuery();
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<GalleryDTO>> GetByID(int id)
        {
            var query = new GetGalleryByIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GalleryDTO>> PostPicture([FromBody] GalleryDTO obj)
        {
            var query = new PostGalleryCommand(obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpPatch("PatchByID/{id}")]
        public async Task<ActionResult<GalleryDTO>> UpdateGalleryAccount(int id, [FromBody] GalleryDTO obj)
        {
            var query = new UpdateGalleryCommand(id, obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult<GalleryDTO>> DeleteBankAccount(int id)
        {
            var query = new DeleteGalleryCommand(id);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }
    }
}

