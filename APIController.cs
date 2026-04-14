
using Microsoft.AspNetCore.Mvc;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            var invoices = new List<dynamic>
            {
                new { invoiceID = 1, customerName = "John Doe" },
                new { invoiceID = 2, customerName = "Jane Smith" }
            };

            return Ok(new { message = "Data fetched", invoices });
        }
    }
}
