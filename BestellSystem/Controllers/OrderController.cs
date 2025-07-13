using BestellSystem.Domain.Entities;
using BestellSystem.Domain.ValueObjects;
using BestellSystem.Dtos;
using Microsoft.AspNetCore.Mvc;
using BestellSystem.Application.Services;

namespace BestellSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private static List<Bestellung> _orders = new();

        [HttpGet]
        public IActionResult AllOrders()
        {
            return Ok(_orders);
        }

        private static BestellService _service = new BestellService();

        [HttpPost]
        public IActionResult NewOrder([FromBody] CreateOrderDto dto)
        {
            var bestellung = _service.ErstelleBestellung(dto);
            bestellung.Id = _orders.Count + 1; // Simulate ID generation
            _orders.Add(bestellung);
            return Ok(bestellung);
        }

    }
}
