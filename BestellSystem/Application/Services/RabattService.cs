using BestellSystem.Domain.Entities;

namespace BestellSystem.Application.Services
{
    public class RabattService
    {
        public decimal BerechneRabatt(Bestellung bestellung)
        {
            int gesamtAnzahl = bestellung.Positionen.Sum(p => p.Anzahl);
            decimal gesamtbetrag = bestellung.Gesamtbetrag;
           
                if (gesamtAnzahl > 5)
                {
                    return gesamtbetrag * 0.9m; // 10% Rabatt
                }
            
            return gesamtbetrag; // Kein Rabatt
        }
    }
}
