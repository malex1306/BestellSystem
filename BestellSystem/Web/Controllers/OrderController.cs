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
        private readonly BestellService _service;
        private readonly IBestellungRepository _repository;
        private readonly PreisPruefService _preisPruefer;
        private readonly RabattService _rabattService;

        public OrderController(
            BestellService service,
            IBestellungRepository repository,
            PreisPruefService preisPruefer,
            RabattService rabattService)
        {
            _service = service;
            _repository = repository;
            _preisPruefer = preisPruefer;
            _rabattService = rabattService;
        }


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
