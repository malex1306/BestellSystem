namespace BestellSystem.Dtos
{
    public class CreateOrderDto
    {
        public string Kunde { get; set; }
        public List <PositionDto> Position { get; set;}
    }

    public class PositionDto
    {
        public string ProduktName { get; set; }
        public decimal EinzelPreis { get; set; }
        public int Anzahl { get; set; }
    }
}
