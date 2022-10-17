using JDNowTop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JDNowTop.Data.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> _options) : base(_options) { }

        public DbSet<UserData> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Week> Weeks { get; set; }

        protected override void OnModelCreating(ModelBuilder _builder)
        {
            base.OnModelCreating(_builder);

            _builder.Entity<Song>()
                .HasKey(e => e.MapName);

            _builder.Entity<Position>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            _builder.Entity<Week>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            _builder.Entity<Position>()
                .HasOne(p => p.Song)
                .WithMany(s => s.Positions)
                .HasForeignKey(p => p.MapName);

            _builder.Entity<Week>()
                .HasMany(w => w.Positions)
                .WithOne(p => p.Week)
                .HasForeignKey(p => p.WeekId);

            _builder.Entity<UserData>()
                .HasKey(u => u.Id);
        }
    }
}
