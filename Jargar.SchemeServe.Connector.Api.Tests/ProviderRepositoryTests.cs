using Jargar.SchemeServe.Connector.Api.Apis.Db;
using Jargar.SchemeServe.Connector.Api.Apis.Db.Repository;
using Jargar.SchemeServe.Connector.Api.DataContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jargar.SchemeServe.Connector.Api.Tests;

public class ProviderRepositoryTests
{
    [Fact]
    public async Task GetProviderAsync_WithValidProviderId_ReturnsProvider()
    {
        // Arrange
        ServiceProvider serviceProvider = new ServiceCollection()
            .AddDbContext<ProviderDbContext>(options => options.UseInMemoryDatabase("InMemoryProviderDatabase"))
            .BuildServiceProvider();

        using IServiceScope scope = serviceProvider.CreateScope();
        ProviderDbContext dbContext = scope.ServiceProvider.GetRequiredService<ProviderDbContext>();

        const string providerId = "validProviderId";
        Provider provider = new() { ProviderId = providerId, CacheExpiration = DateTime.UtcNow.AddHours(1) };
        dbContext.Providers.Add(provider);
        dbContext.SaveChanges();

        ProviderRepository repository = new(dbContext);

        // Act
        Provider? result = await repository.GetProviderAsync(providerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(providerId, result.ProviderId);
    }

    [Fact]
    public async Task GetProviderAsync_WithExpiredCache_ReturnsNull()
    {
        // Arrange
        ServiceProvider serviceProvider = new ServiceCollection()
            .AddDbContext<ProviderDbContext>(options => options.UseInMemoryDatabase("InMemoryProviderDatabase"))
            .BuildServiceProvider();

        using IServiceScope scope = serviceProvider.CreateScope();
        ProviderDbContext dbContext = scope.ServiceProvider.GetRequiredService<ProviderDbContext>();

        const string providerId = "expiredProviderId";
        Provider provider = new() { ProviderId = providerId, CacheExpiration = DateTime.UtcNow.AddHours(-1) };
        dbContext.Providers.Add(provider);
        dbContext.SaveChanges();

        ProviderRepository repository = new(dbContext);

        // Act
        Provider? result = await repository.GetProviderAsync(providerId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task AddProviderAsync_AddsProviderToDatabase()
    {
        // Arrange
        ServiceProvider serviceProvider = new ServiceCollection()
            .AddDbContext<ProviderDbContext>(options => options.UseInMemoryDatabase("InMemoryProviderDatabase"))
            .BuildServiceProvider();

        using IServiceScope scope = serviceProvider.CreateScope();
        ProviderDbContext dbContext = scope.ServiceProvider.GetRequiredService<ProviderDbContext>();

        Provider provider = new() { ProviderId = "newProvider", CacheExpiration = DateTime.UtcNow.AddHours(1) };
        ProviderRepository repository = new(dbContext);

        // Act
        await repository.AddProviderAsync(provider);

        // Assert
        Provider? result = await dbContext.Providers.FirstOrDefaultAsync(p => p.ProviderId == "newProvider");
        Assert.NotNull(result);
    }
}
