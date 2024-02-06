using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.InvoiceQueries;
using QArte.API.Commands.PaymentMethodCommands;
using QArte.API.Queries.PaymentMethodQueries;


/*
public Task<PaymentMethodDTO> DeleteAsync(int id)
 public Task<IEnumerable<PaymentMethodDTO>> GetAsync()
public Task<PaymentMethodDTO> GetPaymentMethodByID(int id)
public Task<PaymentMethodDTO> GetPaymentMethodByPaymentType(EPaymentMethods ePaymentMethod)
 public Task<PaymentMethodDTO> GetPaymentMethodByUserID(int id)
 public Task<PaymentMethodDTO> PostAsync(PaymentMethodDTO obj)
 public Task<PaymentMethodDTO> UpdateAsync(int id, PaymentMethodDTO obj)
*/

namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodsService _paymentMethod;
        private readonly IMediator _mediatR;


        public PaymentMethodController(IPaymentMethodsService paymentMethod, IMediator mediator)
        {
            _paymentMethod = paymentMethod;
            _mediatR = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethodDTO>>> GetAll()
        {
            var query = new GetPaymentMethodAllQuery();
            var request = await _mediatR.Send(query);
            return Ok(request);
        }


        [HttpGet("GetByFeeID/{feeId}")]
        public async Task<ActionResult<PaymentMethodDTO>> GetByUserID(int id)
        {
            var query = new GetInvoiceByFeeIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }


        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<PaymentMethodDTO>> GetByID(int id)
        {
            var query = new GetPaymentMethodByIDQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<PaymentMethodDTO>> PostPaymentMethod([FromBody] PaymentMethodDTO obj)
        {
            var query = new PostPaymentMethodCommand(obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpPatch("PatchByID/{id}")]
        public async Task<ActionResult<PaymentMethodDTO>> UpdatePaymentMethod(int id, [FromBody] PaymentMethodDTO obj)
        {
            var query = new UpdatePaymentMethodCommand(id, obj);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult<PaymentMethodDTO>> DeletePaymentMethod(int id)
        {
            var query = new DeletePaymentMethodCommand(id);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

    }
}