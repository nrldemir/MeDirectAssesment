using LightsOutGame.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LightsOutGame.Data.Infrastructure
{
    public class LightsOutGameDbContext : DbContext
    {
        public LightsOutGameDbContext(DbContextOptions<LightsOutGameDbContext> options) : base(options)
        {

        }
        public DbSet<GameSetting> GameSetting { get; set; }
        public DbSet<Player> Player { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}
