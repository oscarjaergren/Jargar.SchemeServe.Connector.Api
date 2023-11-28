using Jargar.SchemeServe.Connector.Api.DataContract;

namespace Jargar.SchemeServe.Connector.Api.Apis.Db.Repository;

public interface IProviderRepository
{
    Task<Provider?> GetProviderAsync(string providerId);

    Task AddProviderAsync(Provider provider);
}
