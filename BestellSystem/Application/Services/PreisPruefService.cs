using BestellSystem.Domain.Entities;
using BestellSystem.Domain.ValueObjects;
using BestellSystem.Dtos;

namespace BestellSystem.Application.Services
{
    public class PreisPruefService
    {
        public bool IstGueltig(Bestellung bestellung)
        {
            foreach (var position in bestellung.Positionen)
            {
                if (position.EinzelPreis <= 0)
                {
                    return false; // Einzelpreis muss größer als 0 sein
                }
            }

            return true;
        }
    }
}
