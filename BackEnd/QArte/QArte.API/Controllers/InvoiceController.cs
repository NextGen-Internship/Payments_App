using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.InvoiceQueries;
using QArte.API.Commands.InvoiceCommands;
using QArte.API.Queries.BankAccountQueries;

namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMediator _mediatR;


        public InvoiceController(IInvoiceService invoiceService, IMediator mediator)
        {
            _invoiceService = invoiceService;
            _mediatR = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAll()
        {
            var query = new GetInvoiceAllQuery();
            var request = await _mediatR.Send(query);
            return Ok(request);
        }


        [HttpGet("GetByBankAccountID/{id}")]
        public async Task<ActionResult<InvoiceDTO>> GetByBankAccountID(int id)
        {
            var query = new GetInvoiceBankAccountByIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpGet("GetByFeeID/{feeId}")]
        public async Task<ActionResult<InvoiceDTO>> GetByFeeID(int id)
        {
            var query = new GetInvoiceByFeeIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }


        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<InvoiceDTO>> GetByID(int id)
        {
            var query = new GetInvoiceByIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceDTO>> PostInvoice([FromBody] InvoiceDTO obj)
        {
            var query = new PostInvoiceCommand(obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpPatch("PatchByID/{id}")]
        public async Task<ActionResult<InvoiceDTO>> UpdateInvoice(int id, [FromBody] InvoiceDTO obj)
        {
            var query = new UpdateInvoiceCommand(id, obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult<InvoiceDTO>> DeleteInvoice(int id)
        {
            var query = new DeleteInvoiceCommand(id);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

    }
}