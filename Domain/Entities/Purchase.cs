namespace Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime PurchasedAtUtc { get; set; }
        public decimal TotalAmount { get; set; }

        // Simplified: total tickets count for MVP
        public int TotalTickets { get; set; }
    }
}