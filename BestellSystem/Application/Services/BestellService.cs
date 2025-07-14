using BestellSystem.Application.Repositories;
using BestellSystem.Domain.Entities;
using BestellSystem.Domain.ValueObjects;
using BestellSystem.Dtos;

namespace BestellSystem.Application.Services
{
    public class BestellService
    {
        private readonly IBestellungRepository _repository;
        public BestellService(IBestellungRepository repository)
        {
            _repository = repository;
        }

        public Bestellung ErstelleBestellung(CreateOrderDto dto)
        {
          var bestellung = new Bestellung
          {
              Id = 0,
              Kunde = dto.Kunde
          };

          foreach (var pos in dto.Position)
          {
              var position = new BestellPosition(pos.ProduktName, pos.EinzelPreis, pos.Anzahl);
              bestellung.FuegePositionHinzu(position);
          }

          return bestellung;
        }
    }
}
