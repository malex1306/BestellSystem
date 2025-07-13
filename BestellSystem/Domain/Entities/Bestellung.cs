using BestellSystem.Domain.ValueObjects;

namespace BestellSystem.Domain.Entities
{
    public class Bestellung
    {
        public int Id { get; set; }
        public string Kunde { get; set; }
        public DateTime Erstellungsdatum { get; set; } = DateTime.UtcNow;
        public List<BestellPosition> Positionen { get; set; } = new List<BestellPosition>();
        public decimal Gesamtbetrag => Positionen.Sum(p => p.EinzelPreis * p.Anzahl);


        public void FuegePositionHinzu(BestellPosition position)
        {
            Positionen.Add(position);
        }
    }
}
