using BestellSystem.Application.Repositories;
using BestellSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BestellSystem.Infrastructur.Persistence
{
    public class EfCoreBestellungRepository : IBestellungRepository
    {
        private readonly BestellDbContext _context;

        public EfCoreBestellungRepository(BestellDbContext context)
        {
            _context = context;
        }

        public void Add(Bestellung bestellung)
        {
            _context.Bestellungen.Add(bestellung);
            _context.SaveChanges();
        }

        public List<Bestellung> GetAll()
        {
            return _context.Bestellungen
                .Include(b => b.Positionen)
                .ToList();
        }

        public Bestellung? GetById(int id)
        {
            return _context.Bestellungen
                .Include(b => b.Positionen)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
