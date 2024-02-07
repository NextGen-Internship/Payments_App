using System;
using QArte.Services.Services;
using QArte.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using QArte.Services.DTOs;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.API.Queries.BankAccountQueries;
using QArte.API.Commands.BankAccountCommands;

namespace QArte.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BankAccountController : ControllerBase
	{

		private readonly IBankAccountService _bankAccountService;
        private readonly IMediator _mediatR;

        public BankAccountController(IBankAccountService bankAccountService, IMediator mediator)
		{
			_bankAccountService = bankAccountService;
			_mediatR = mediator;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccountDTO>>> GetAll()
        {
            var query = new GetBankAccountAllQuery();
            var request = await _mediatR.Send(query);
            return Ok(request);
        }


        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<BankAccountDTO>> GetByID(int id)
		{
			var query = new GetBankAccountByIDQuery(id);
			var result = await _mediatR.Send(query);
            return Ok(result);
		}

        [HttpGet("GetByIBAN/{IBAN}")]
        public async Task<ActionResult<BankAccountDTO>> GetByIBAN(string IBAN)
        {
            var query = new GetBankAccountByIBANQuery(IBAN);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpGet("GetByPaymentMethod/{paymentMethod}")]
        public async Task<ActionResult<List<BankAccountDTO>>> GetByPaymentMethod(string paymentMethod)
        {
            var query = new GetBankAccountByPaymentMethodQuery(paymentMethod);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

		[HttpPost]
		public async Task<ActionResult<BankAccountDTO>> PostBankAccount([FromBody] BankAccountDTO obj)
		{
			var query = new PostBankAccountCommand(obj);
			var request = await _mediatR.Send(query);
			return Ok(request);
		}

		[HttpPatch("PatchByID/{id}")]
		public async Task<ActionResult<BankAccountDTO>> UpdateBankAccount(int id,[FromBody]BankAccountDTO obj)
		{
			var query = new UpdateBankAccountCommand(id,obj);
			var request = await _mediatR.Send(query);
			return Ok(request);
		}


		[HttpDelete("DeleteByID/{id}")]
		public async Task<ActionResult<BankAccountDTO>> DeleteBankAccount(int id)
		{
            var query = new DeleteBankAccountCommand(id);
            var request = await _mediatR.Send(query);
            return Ok(request);
        }

	}
}

