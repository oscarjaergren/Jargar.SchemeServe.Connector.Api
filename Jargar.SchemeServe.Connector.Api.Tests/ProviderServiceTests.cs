using Jargar.SchemeServe.Connector.Api.Apis.Db.Repository;
using Jargar.SchemeServe.Connector.Api.Apis.ProviderService;
using Jargar.SchemeServe.Connector.Api.DataContract;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Jargar.SchemeServe.Connector.Api.Tests;
public class ProviderServiceTests
{
    private readonly Mock<IProviderRepository> providerRepositoryMock;
    private readonly Mock<IHttpClientFactory> httpClientFactoryMock;
    private readonly Mock<ILogger<ProviderService>> loggerMock;

    public ProviderServiceTests()
    {
        providerRepositoryMock = new Mock<IProviderRepository>();
        httpClientFactoryMock = new Mock<IHttpClientFactory>();
        loggerMock = new Mock<ILogger<ProviderService>>();
    }

    [Fact]
    public async Task GetProvider_Returns_DbProvider_When_InRepository()
    {
        const string providerId = "123";
        Provider dbProvider = new() { ProviderId = providerId };

        providerRepositoryMock.Setup(repo => repo.GetProviderAsync(providerId)).ReturnsAsync(dbProvider);

        ProviderService providerService = new(providerRepositoryMock.Object, httpClientFactoryMock.Object, loggerMock.Object);

        Provider? result = await providerService.GetProvider(providerId);

        Assert.Equal(dbProvider, result);
    }

    [Fact]
    public async Task GetProvider_Returns_ExternalProvider_When_NotInRepository()
    {
        // Arrange
        const string providerId = "123";
        Provider externalProvider = new() { ProviderId = providerId };

        providerRepositoryMock.Setup(repo => repo.GetProviderAsync(providerId)).ReturnsAsync((Provider?)null);

        HttpResponseMessage httpResponseMessage = new()
        {
            Content = new StringContent(JsonSerializer.Serialize(externalProvider, ProviderContext.Default.Provider), Encoding.UTF8, "application/json"),
            StatusCode = HttpStatusCode.OK
        };

        Mock<HttpMessageHandler> handler = new();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(httpResponseMessage);

        HttpClient httpClient = new(handler.Object)
        {
            BaseAddress = new Uri("https://api.cqc.org.uk/public/v1/") 
        };

        httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);

        ProviderService providerService = new(providerRepositoryMock.Object, httpClientFactoryMock.Object, loggerMock.Object);

        // Act
        Provider? result = await providerService.GetProvider(providerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(externalProvider.ProviderId, result?.ProviderId);
    }



    [Fact]
    public async Task GetProvider_Returns_Null_When_Exception()
    {
        // Arrange
        const string providerId = "123";

        providerRepositoryMock.Setup(repo => repo.GetProviderAsync(providerId)).ThrowsAsync(new Exception("Simulated exception"));

        ProviderService providerService = new(providerRepositoryMock.Object, httpClientFactoryMock.Object, loggerMock.Object);

        // Act
        Provider? result = await providerService.GetProvider(providerId);

        // Assert
        Assert.Null(result);
    }
}