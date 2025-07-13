using Microsoft.AspNetCore.Mvc;

namespace BestellSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private static List<OrderModel> _orders = new();

        [HttpGet]
        public IActionResult AllOrders()
        {
            return Ok(_orders);
        }

        [HttpPost]
        public IActionResult NewOrder([FromBody] OrderModel order)
        {
            _orders.Add(order);
            return Ok();
        }
    }
}
