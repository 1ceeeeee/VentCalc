using Microsoft.EntityFrameworkCore;
using VentCalc.Models;

namespace VentCalc.Persistence
{
    public class VentCalcDbContext : DbContext
    {
        public VentCalcDbContext(DbContextOptions<VentCalcDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<BuildingKind> BuildingKinds { get; set; }
        public DbSet<BuildingPurpose> BuildingPurposes { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }
    }
}