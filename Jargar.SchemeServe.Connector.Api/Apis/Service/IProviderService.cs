using Jargar.SchemeServe.Connector.Api.DataContract;

namespace Jargar.SchemeServe.Connector.Api.Apis.ProviderService;

public interface IProviderService
{
    Task<Provider?> GetProvider(string providerId);

    Task<ApiProvidersResponse?> GetProviders();
}