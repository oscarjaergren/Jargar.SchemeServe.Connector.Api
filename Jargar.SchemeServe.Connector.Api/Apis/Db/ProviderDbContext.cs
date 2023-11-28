using Jargar.SchemeServe.Connector.Api.DataContract;
using Microsoft.EntityFrameworkCore;
using MyCompiledModels;

namespace Jargar.SchemeServe.Connector.Api.Apis.Db;

public class ProviderDbContext : DbContext
{
    public ProviderDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Provider> Providers { get; set; }

    public DbSet<LastInspection> LastInspections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Provider>()
            .OwnsOne(p => p.LastInspection);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseModel(ProviderDbContextModel.Instance);
    }
}