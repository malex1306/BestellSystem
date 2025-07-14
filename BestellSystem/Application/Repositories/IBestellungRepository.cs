using BestellSystem.Domain.Entities;

namespace BestellSystem.Application.Repositories
{
    public interface IBestellungRepository
    {
        List<Bestellung> GetAll();
        Bestellung? GetById(int id);
        void Add(Bestellung bestellung);
    }
}
