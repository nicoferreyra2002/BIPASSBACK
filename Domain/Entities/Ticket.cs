namespace Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public Concert Concert { get; set; }

        public string Category { get; set; } = "General"; // e.g., General, VIP
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}