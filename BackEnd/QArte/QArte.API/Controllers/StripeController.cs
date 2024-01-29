using Microsoft.AspNetCore.Mvc;
using QArte.Services.Services;
using Stripe;
using Stripe.Checkout;
using QArte.Services.DTOs;


namespace QArte.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StripeController : ControllerBase 
	{
        private readonly StripeService _stripeService;

        public StripeController(StripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost]
        public ActionResult CreateCheckoutSession([FromBody] CheckoutSessionDTO input)
        {
            if (input == null || string.IsNullOrEmpty(input.SuccessUrl) || string.IsNullOrEmpty(input.CancelUrl))
            {
                return BadRequest("SuccessUrl and CancelUrl are required.");
            }

            var session = _stripeService.CreateCheckoutSession(input.SuccessUrl, input.CancelUrl, input.ArtistAccountID);

            return Ok(new { sessionId = session.Id });
        }
    }

}