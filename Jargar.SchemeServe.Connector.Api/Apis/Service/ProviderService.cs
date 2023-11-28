using Jargar.SchemeServe.Connector.Api.DataContract;
using Jargar.SchemeServe.Connector.Api.Apis.Db.Repository;

namespace Jargar.SchemeServe.Connector.Api.Apis.ProviderService;

public sealed class ProviderService : IProviderService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IProviderRepository _providerRepository;
    private readonly ILogger<ProviderService> _logger;

    public ProviderService(IProviderRepository providerRepository, IHttpClientFactory httpClientFactory, ILogger<ProviderService> logger)
    {
        _providerRepository = providerRepository;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<Provider?> GetProvider(string providerId)
    {
        try
        {
            Provider? dbProvider = await _providerRepository.GetProviderAsync(providerId);

            if (dbProvider != null)
            {
                return dbProvider;
            }

            Provider? externalProvider = await GetProviderFromExternalApi(providerId);

            if (externalProvider != null)
            {
                externalProvider.CacheExpiration = DateTime.UtcNow.AddMonths(1);
                await _providerRepository.AddProviderAsync(externalProvider);
                return externalProvider;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {FunctionName}", nameof(GetProvider));
            return null;
        }
    }

    public Task<ApiProvidersResponse?> GetProviders()
    {
        var client = _httpClientFactory.CreateClient("ProviderClient");
        return client.GetFromJsonAsync("providers", ApiProvidersResponseContext.Default.ApiProvidersResponse);
    }

    private Task<Provider?> GetProviderFromExternalApi(string providerId)
    {
        var client = _httpClientFactory.CreateClient("ProviderClient");
        return client.GetFromJsonAsync("providers/" + providerId, ProviderContext.Default.Provider);
    }
}
