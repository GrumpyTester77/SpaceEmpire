using SpaceEmpire4XTracker.Models;
using System.Data.Entity;

namespace SpaceEmpire4XGameTracker.Data
{
    public class SpaceEmpire4XDb : DbContext
    {
        public DbSet<TechnologyViewModel> Technology { get; set; }

        public DbSet<TechnologyLevelViewModel> TechnologyLevel { get; set; }

        public DbSet<CostViewModel> Cost { get; set; }
    }
}
