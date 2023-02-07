using Microsoft.AspNetCore.Mvc;
using Stripe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe.Checkout;

public class StripeOptions
{
    public string option { get; set; }
}

namespace Marketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : Controller
    {

        [HttpPost("amount")]
        public ActionResult pay(int amount)
        {
            StripeConfiguration.ApiKey = "sk_test_51M0O23H6K2vokGz3pPZbklrXWrDplNSVor91FO61WHkmfMJHmw75a57kRsne4AMWvLVdLIgFHNbTE5w76Mda556N00Oddt7Gec";


                var options = new ChargeCreateOptions
                {
                    Amount = amount,
                    Currency = "usd",
                    Source = "tok_mastercard",
                    Description = "Test Charge",
                };
                var service = new ChargeService();
                service.Create(options);
                return Ok();
        }

        

    }
}
