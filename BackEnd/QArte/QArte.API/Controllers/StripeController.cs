using Microsoft.AspNetCore.Mvc;
using QArte.Services.Services;
using Stripe;
using Stripe.Checkout;
using QArte.Services.DTOs;
using System.IO;
using System.Text.Json;
using QArte.Persistance.PersistanceConfigurations;
using QArte.Services.ServiceInterfaces;

namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StripeController : ControllerBase 
	{
        private readonly StripeService _stripeService;
        private readonly IUserService _userService;

        public StripeController(StripeService stripeService, IUserService userService)
        {
            _stripeService = stripeService;
            _userService = userService;
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
    }

}