namespace Domain.Entities
{
    public class Concert
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Venue { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime EventDateUtc { get; set; }
        public bool IsStreamingEnabled { get; set; }
        public string? StreamingUrl { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}