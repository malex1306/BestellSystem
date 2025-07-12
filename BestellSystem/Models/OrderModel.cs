namespace BestellSystem.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string Costumer { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
