using Drilling.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drilling.Infrastructure
{
    public class DrillingContext : DbContext
    {
        public DrillingContext(DbContextOptions<DrillingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<DrillBlockPoint> DrillBlockPoints { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HolePoint> HolePoints { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
