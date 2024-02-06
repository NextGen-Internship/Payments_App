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
        private readonly StripeService _stripeService;
        private readonly IUserService _userService;
        private readonly IFeeService _feeService;

        public StripeController(StripeService stripeService, IUserService userService, IFeeService feeService)
        {
            _stripeService = stripeService;
            _userService = userService;
            _feeService = feeService;
        }


        [HttpGet("getPubKey")]
        public async Task<ActionResult<string>> GetPubKey()
        {
            string jsonFilePath = "./appsettings.Development.json";

            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);

            var stripeConfig = JsonSerializer.Deserialize<stripeconfig>(jsonContent);


            return Ok(stripeConfig.Stripe.PubKey);
        }


        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession([FromBody] SuccCancelUrlDTO urls)
        {
            var domain = "https://localhost:7191";

            var options = new SessionCreateOptions()
            {
                LineItems = new List<SessionLineItemOptions>()
               {
                   new SessionLineItemOptions()
                   {
                       Price = "price_1OgOm2Ly4Nh7di81hZ8EUENq",
                       Quantity = 1,
                   }
               },
                PaymentMethodTypes = new List<string>()
                {
                    "card"
                },
                Metadata = new Dictionary<string, string>
                {
                    { "userID", urls.UserID.ToString() }
                },
                Mode = "payment",
                SuccessUrl = urls.SuccessURL,
                CancelUrl = urls.CancelURL
            };
            var service = new SessionService();
            Session session = service.Create(options);

            return new OkObjectResult(new { RedirectUrl = session.Url });
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


        [HttpPost("stripe-webhook")]
        public async Task<IActionResult> StripeWebhook()
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


                    


                    FeeDTO newFee = new FeeDTO()
                    {
                        ID = 0,
                        Amount = amount.Value,
                        Currency = currency,
                        ExchangeRate = 1.0,
                    };

                    await _feeService.PostAsync(newFee);
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