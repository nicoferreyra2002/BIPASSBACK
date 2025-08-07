using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Concert> Concerts => Set<Concert>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Purchase> Purchases => Set<Purchase>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Concert>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Title).IsRequired().HasMaxLength(200);
                entity.Property(c => c.Venue).HasMaxLength(200);
                entity.Property(c => c.City).HasMaxLength(100);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Category).HasMaxLength(100);
                entity.Property(t => t.Price).HasColumnType("decimal(18,2)");
                entity.HasOne(t => t.Concert)
                      .WithMany(c => c.Tickets)
                      .HasForeignKey(t => t.ConcertId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.TotalAmount).HasColumnType("decimal(18,2)");
                entity.HasOne(p => p.User)
                      .WithMany()
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}