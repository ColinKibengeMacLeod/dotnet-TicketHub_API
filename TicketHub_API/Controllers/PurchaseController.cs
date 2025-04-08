using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketHubAPI;
namespace TicketHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        private readonly ILogger<PurchaseController> _logger;
        private readonly IConfiguration _configuration;

        //Constructor
        public PurchaseController(ILogger<PurchaseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Purchase Controller - GET");
        }

        [HttpPost]
        public IActionResult Post(Purchase purchase)
        {
            return Ok("Hello from Purchase Controller - POST");
        }
    }
}
