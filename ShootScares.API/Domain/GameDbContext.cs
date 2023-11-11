using Microsoft.EntityFrameworkCore;
using ShootScares.API.Domain.Entities;

namespace ShootScares.API.Domain
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }
        
        DbSet<Player> Players { get; set; }
        DbSet<GameResult> GameResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data
            modelBuilder.Entity<Player>().HasData(new Player { Id = 1, Name = "test" });
            modelBuilder.Entity<GameResult>().HasData(new GameResult {Id = 1, PlayerId = 1, Date = DateTime.Now});
        }
    }
}
