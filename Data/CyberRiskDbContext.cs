using CyberRiskTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CyberRiskTracker.Data
{
    public class CyberRiskDbContext : DbContext
    {
        private readonly IHostEnvironment? _env;
        public CyberRiskDbContext(DbContextOptions<CyberRiskDbContext> options, IHostEnvironment? env = null)
        : base(options)
        {
            _env = env;
        }

        public DbSet<RiskItemEntity> Risks { get; set; }
        public DbSet<AssetEntity> Assets { get; set; }
        public DbSet<LoginAttemptEntity> LoginAttempts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_env != null && _env.IsDevelopment())
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                if (clrType != null && clrType.Name.EndsWith("Entity"))
                {
                    var tableName = clrType.Name.Replace("Entity", string.Empty);

                    // Use reflection to call the generic Entity<TEntity>().ToTable("...") method
                    var method = typeof(ModelBuilder)
                        .GetMethods()
                        .First(m => m.Name == nameof(ModelBuilder.Entity)
                                 && m.IsGenericMethod
                                 && m.GetParameters().Length == 0);

                    var genericMethod = method.MakeGenericMethod(clrType);
                    var entityBuilder = genericMethod.Invoke(modelBuilder, null);

                    // Call ToTable on the resulting EntityTypeBuilder<T>
                    var toTableMethod = entityBuilder
                        .GetType()
                        .GetMethod(nameof(RelationalEntityTypeBuilderExtensions.ToTable), new[] { typeof(string) });

                    toTableMethod?.Invoke(entityBuilder, new object[] { tableName });
                }
            }
        }

    }
} 

