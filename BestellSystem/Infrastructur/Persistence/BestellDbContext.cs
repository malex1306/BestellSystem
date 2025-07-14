using BestellSystem.Domain.Entities;
using BestellSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BestellSystem.Infrastructur.Persistence
{
    public class BestellDbContext : DbContext
    {
        public BestellDbContext(DbContextOptions<BestellDbContext> options)
            : base(options) { }

        public DbSet<Bestellung> Bestellungen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bestellung>()
                .HasMany(b => b.Positionen)
                .WithOne()
                .HasForeignKey(p => p.BestellungId);

            modelBuilder.Entity<BestellPosition>()
                .HasKey(p => p.Id); // 
        }
    }
}