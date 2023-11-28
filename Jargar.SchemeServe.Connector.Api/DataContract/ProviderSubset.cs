using System.Text.Json.Serialization;

namespace Jargar.SchemeServe.Connector.Api.DataContract;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(ApiProvidersResponse))]
[JsonSerializable(typeof(List<ProviderSubset>))]
[JsonSerializable(typeof(IEnumerable<ProviderSubset>))]
internal partial class ApiProvidersResponseContext : JsonSerializerContext
{
}

public record ProviderSubset
{
    public required string ProviderId { get; set; }

    public required string ProviderName { get; set; }
}

public record ApiProvidersResponse
{
    public required int Total { get; set; }
    public required string FirstPageUri { get; set; }
    public required int Page { get; set; }
    public required string PreviousPageUri { get; set; }
    public required string LastPageUri { get; set; }
    public required string NextPageUri { get; set; }
    public required int PerPage { get; set; }
    public required int TotalPages { get; set; }
    public required List<ProviderSubset> Providers { get; set; }
}