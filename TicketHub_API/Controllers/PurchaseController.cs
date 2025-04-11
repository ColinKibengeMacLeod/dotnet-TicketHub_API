using Azure.Storage.Queues;
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

        // Constructor
        public PurchaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Purchase Controller - GET");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Purchase purchase)
        {

            if (ModelState.IsValid == false) {
                
                return BadRequest(ModelState);
            
            }

            string queueName = "tickethubqueue";

            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            //Serialize OBJ to JSON

            string message = System.Text.Json.JsonSerializer.Serialize(purchase);

            //Send message to queue

            await queueClient.SendMessageAsync(message);

            return Ok("Message successfully posted to queue!");

        }
    }
}
