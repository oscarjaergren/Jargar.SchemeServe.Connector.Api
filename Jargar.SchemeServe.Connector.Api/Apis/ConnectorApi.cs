using Jargar.SchemeServe.Connector.Api.Apis.ProviderService;
using Jargar.SchemeServe.Connector.Api.DataContract;
using Microsoft.AspNetCore.Mvc;

namespace Jargar.SchemeServe.Connector.Api.Apis;

public static class ConnectorApi
{
    const string Tag = "Connector";

    internal static WebApplication MapConnectorApi(this WebApplication app)
    {
        app.MapGet("/api/connectors", GetProviders)
          .WithTags(Tag)
          .WithName(nameof(GetProviders));

        app.MapGet("/api/connectors/{providerId}", GetProvider)
            .WithTags(Tag)
            .WithName(nameof(GetProvider));

        return app;
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(List<ProviderSubset>), 200)]
    private static async Task<IResult> GetProviders(ILoggerFactory loggerFactory, IProviderService providerService)
    {
        var logger = loggerFactory.CreateLogger(nameof(ConnectorApi));
        logger.LogDebug("Getting list of providers");

        var providers = await providerService.GetProviders();

        return providers?.Providers != null
         ? Results.Ok(providers?.Providers)
         : Results.NotFound();
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(Provider), 200)]
    public static async Task<IResult> GetProvider(string providerId, ILoggerFactory loggerFactory, IProviderService providerService)
    {
        if (string.IsNullOrWhiteSpace(providerId))
        {
            return Results.BadRequest($"{providerId}' cannot be null or whitespace.");
        }

        ILogger logger = loggerFactory.CreateLogger(nameof(ConnectorApi));
        logger.LogDebug("Getting provider with id {ProviderId}", providerId);

        Provider? provider = await providerService.GetProvider(providerId);

        return provider != null
            ? Results.Ok(provider)
            : Results.NotFound();
    }
}
