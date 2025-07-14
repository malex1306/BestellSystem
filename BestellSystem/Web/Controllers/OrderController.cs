using BestellSystem.Application.Repositories;
using BestellSystem.Domain.Entities;
using BestellSystem.Domain.ValueObjects;
using BestellSystem.Dtos;
using Microsoft.AspNetCore.Mvc;
using BestellSystem.Application.Services;

namespace BestellSystem.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private static IBestellungRepository _repository = new InMemoryBestellungRepository();
        private static BestellService _service = new BestellService();
        private static PreisPruefService _preisPruefer = new PreisPruefService();
        private static RabattService _rabattService = new RabattService();


        [HttpGet]
        public IActionResult AllOrders()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public IActionResult NewOrder([FromBody] CreateOrderDto dto)
        {
            var bestellung = _service.ErstelleBestellung(dto);
            if (!_preisPruefer.IstGueltig(bestellung))
            {
                return BadRequest("Ungültige Einzelpreise in der Bestellung.");
            }

            var rabatt = _rabattService.BerechneRabatt(bestellung);

            bestellung.Id = _repository.GetAll().Count + 1; 
            _repository.Add(bestellung);
            return Ok(new
            {
                Orginal = bestellung.Gesamtbetrag,
                Rabatt = rabatt,
                Bestellung = bestellung
            });
        }
    }
}
