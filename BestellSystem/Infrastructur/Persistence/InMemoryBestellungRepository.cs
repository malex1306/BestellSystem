using BestellSystem.Application.Repositories;
using BestellSystem.Domain.Entities;

namespace BestellSystem.Infrastructur.Persistence
{
    public class InMemoryBestellungRepository : IBestellungRepository
    {
        private readonly List<Bestellung> _bestellungen = new();

        public List<Bestellung> GetAll()
        {
            return _bestellungen;
        }

        public Bestellung? GetById(int id)
        {
            return _bestellungen.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Bestellung bestellung)
        {
            _bestellungen.Add(bestellung);
        }
    }
}
