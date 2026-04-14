
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {
            var items = new List<dynamic>
            {
                new { itemID = 1, invoiceID = 1, name = "Widget A", price = 19.99m },
                new { itemID = 2, invoiceID = 1, name = "Widget B", price = 29.99m },
                new { itemID = 3, invoiceID = 1, name = "Service C", price = 49.99m }
            };

            return Ok(new { items });
        }
    }
}
