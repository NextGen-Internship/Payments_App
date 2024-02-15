using Microsoft.AspNetCore.Mvc;
using QArte.Services.Services;
using Stripe;
using Stripe.Checkout;
using QArte.Services.DTOs;
using System.IO;
using System.Text.Json;
using QArte.Persistance.PersistanceConfigurations;
using QArte.Services.ServiceInterfaces;
using MediatR;


namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StripeController : ControllerBase 
	{
        private readonly IStripeService _stripeService;
        private readonly IUserService _userService;
        private readonly IFeeService _feeService;
        private readonly IBankAccountService _bankAccountService;
        private readonly ISettlementCycleService _settlementCycleService;

        public StripeController(IStripeService stripeService, IUserService userService, IFeeService feeService, IBankAccountService bankAccountService, ISettlementCycleService settlementCycleService)
        {
            _stripeService = stripeService;
            _userService = userService;
            _feeService = feeService;
            _bankAccountService = bankAccountService;
            _settlementCycleService = settlementCycleService;
        }


        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession([FromBody] SuccCancelUrlDTO urls)
        {

            try
            {
                Session session = _stripeService.CreateCheckoutSession(urls).Result;

                return new OkObjectResult(new { RedirectUrl = session.Url });
            }
            catch (StripeException stripeException)
            {
                return BadRequest($"Stripe Exception: {stripeException.Message}");
            }

        }



        [HttpPost("create-transfer")]
        public ActionResult CreateTransfer([FromBody] TransferPaymentToConnectDTO transfer)
        {

            UserDTO user = _userService.GetUserByID(transfer.userID).Result;

            Transfer curTransfer = _stripeService.CreateTansferAsync(user, transfer.amount, transfer.currency).Result;

            if (curTransfer is null)
            {
                return NoContent();
            }

            return Ok(curTransfer.Created);

        }




        [HttpPost("stripe-payment-webhook")]
        public async Task<IActionResult> StripePaymentWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            const string secret = "whsec_b30a7f6c8cec8ac6e15fcea10853be0a4cf663ecc3b638827bca61a73aafbd86";

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    secret
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;

                    var amount = session.AmountTotal;

                    var userID = int.Parse(session.Metadata["userID"]);

                    var currency = session.Currency;

                    var userToTransferMoneyTo = await _userService.GetUserByID(userID);

                    var userBankAccount = await _bankAccountService.GetByIDAsync(userToTransferMoneyTo.BankAccountID);

                    FeeDTO newFee = new FeeDTO()
                    {
                        ID = 0,
                        Amount = 10,
                        Currency = currency,
                        ExchangeRate = 1.0,
                    };

                    var newFeePosted = await _feeService.PostAsync(newFee);

                    InvoiceDTO newInvoice = new InvoiceDTO()
                    {
                        ID = 0,
                        TotalAmount = amount.Value - (amount.Value * newFee.Amount / 100),
                        InvoiceDate = DateTime.Today, //change
                        BankAccountID = userBankAccount.ID,
                        FeeID = newFeePosted.ID
                    };

                    await _bankAccountService.AddInvoice(userBankAccount.ID, newInvoice);


                    await _stripeService.CreateTansferAsync(userToTransferMoneyTo, newInvoice.TotalAmount, currency);

                     
                }

            }
            catch(Exception ex)
            {
                return BadRequest("Error processing Stripe webhook");
            }


            return Ok();
        }
    }
}