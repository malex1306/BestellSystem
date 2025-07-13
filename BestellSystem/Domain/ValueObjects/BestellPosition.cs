namespace BestellSystem.Domain.ValueObjects
{
    public class BestellPosition
    {
        public string ProduktName { get; }
        public decimal EinzelPreis { get; }
        public int Anzahl { get; }

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
