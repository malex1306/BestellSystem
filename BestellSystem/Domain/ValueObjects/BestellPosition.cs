namespace BestellSystem.Domain.ValueObjects
{
    public class BestellPosition
    {
        public int Id { get; set; } 

        public string ProduktName { get; set; }
        public decimal EinzelPreis { get; set; }
        public int Anzahl { get; set; }

        public int BestellungId { get; set; } 

        // Konstruktor (optional für EF Core, aber hilfreich bei Domain Logik)
        public BestellPosition(string produktName, decimal einzelPreis, int anzahl)
        {
            ProduktName = produktName;
            EinzelPreis = einzelPreis;
            Anzahl = anzahl;
        }

        public decimal BerechneZwischensumme()
        {
            return Anzahl * EinzelPreis;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not BestellPosition other) return false;

            return ProduktName == other.ProduktName &&
                   EinzelPreis == other.EinzelPreis &&
                   Anzahl == other.Anzahl;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProduktName, EinzelPreis, Anzahl);
        }
    }
}