using Jargar.SchemeServe.Connector.Api.DataContract;
using Microsoft.EntityFrameworkCore;

namespace Jargar.SchemeServe.Connector.Api.Apis.Db.Repository;

public class ProviderRepository : IProviderRepository
{
    private readonly ProviderDbContext _dbContext;

    public ProviderRepository(ProviderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Provider?> GetProviderAsync(string providerId)
    {
        Provider? provider = await _dbContext.Providers
            .FirstOrDefaultAsync(p => p.ProviderId == providerId);

        if (provider == null)
        {
            return null;
        }

        if (provider.CacheExpiration <= DateTime.UtcNow)
        {
            RemoveAndSave(provider);
            return null;
        }

        return provider;
    }

    private void RemoveAndSave(Provider provider)
    {
        _dbContext.Providers.Remove(provider);
        _dbContext.SaveChanges();
    }

    public async Task AddProviderAsync(Provider provider)
    {
        await _dbContext.Providers.AddAsync(provider);
        await _dbContext.SaveChangesAsync();
    }
}