namespace Jargar.SchemeServe.Connector.Api.DataContract;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(Provider))]

[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(double))]
[JsonSerializable(typeof(DateTime))]

[JsonSerializable(typeof(Provider[]))]

[JsonSerializable(typeof(IEnumerable<Provider>))]
public partial class ProviderContext : JsonSerializerContext
{
}

public record Provider
{
    [Column(TypeName = "TEXT")]  // Specify the column type as TEXT
    public required string ProviderId { get; set; }

    public string OrganisationType { get; set; } = string.Empty;
    public string OwnershipType { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BrandId { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public string RegistrationStatus { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public string CompaniesHouseNumber { get; set; } = string.Empty;
    public string CharityNumber { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string PostalAddressLine1 { get; set; } = string.Empty;
    public string PostalAddressLine2 { get; set; } = string.Empty;
    public string PostalAddressTownCity { get; set; } = string.Empty;
    public string PostalAddressCounty { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Uprn { get; set; } = string.Empty;
    public double OnspdLatitude { get; set; }
    public double OnspdLongitude { get; set; }
    public string MainPhoneNumber { get; set; } = string.Empty;
    public string InspectionDirectorate { get; set; } = string.Empty;
    public string Constituency { get; set; } = string.Empty;
    public string LocalAuthority { get; set; } = string.Empty;

    public DateTime CacheExpiration { get; set; }

    public LastInspection LastInspection { get; set; } = new LastInspection();
}

[JsonSerializable(typeof(LastInspection))]
public record class LastInspection
{
    public DateTime Date { get; set; }
}
