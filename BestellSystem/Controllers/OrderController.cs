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
        private static PreisPruefService _preisPruefer = new PreisPruefService();
        private static RabattService _rabattService = new RabattService();

        [HttpPost]
        public IActionResult NewOrder([FromBody] CreateOrderDto dto)
        {
            var bestellung = _service.ErstelleBestellung(dto);
            if (!_preisPruefer.IstGueltig(bestellung))
            {
                return BadRequest("Ungültige Einzelpreise in der Bestellung.");
            }

            var rabatt = _rabattService.BerechneRabatt(bestellung);

            bestellung.Id = _orders.Count + 1; // Simulate ID generation
            _orders.Add(bestellung);
            return Ok(new
            {
                Orginal = bestellung.Gesamtbetrag,
                Rabatt = rabatt,
                Bestellung = bestellung
            });
        }
    }
}
