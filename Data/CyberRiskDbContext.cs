using CyberRiskTracker.Models;
using Microsoft.EntityFrameworkCore; 

namespace CyberRiskTracker.Data
{
    public class CyberRiskDbContext : DbContext
    {
        public CyberRiskDbContext(DbContextOptions<CyberRiskDbContext> options) : base(options) { }
        public DbSet<RiskItem> Risks => Set<RiskItem>();
        public DbSet<Asset> Assets => Set<Asset>();
    }
}
