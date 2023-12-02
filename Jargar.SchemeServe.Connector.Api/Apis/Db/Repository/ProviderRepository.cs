using Dapper;
using Jargar.SchemeServe.Connector.Api.DataContract;
using Microsoft.Data.Sqlite;
using System.Text.Json;

namespace Jargar.SchemeServe.Connector.Api.Apis.Db.Repository;

public class ProviderRepository : IProviderRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public ProviderRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public async Task<Provider?> GetProviderAsync(string providerId)
    {
        using var connection = new SqliteConnection(_databaseConfig.Name);
        await connection.OpenAsync();

        Provider? provider = await GetProvider(connection, providerId);

        if (provider == null)
        {
            return null;
        }

        if (provider.CacheExpiration <= DateTime.UtcNow)
        {
            RemoveAndSave(connection, provider.ProviderId);
            return null;
        }

        return provider;
    }

    public static async Task<Provider> GetProvider(SqliteConnection connection, string providerId)
    {
        var result = await connection.QueryFirstOrDefaultAsync<Provider>(
            "SELECT * FROM Providers WHERE ProviderId=@providerId",
            new { providerId });

        return result;
    }
    private static void RemoveAndSave(SqliteConnection connection, string providerId)
    {
        const string sql = "DELETE FROM Providers WHERE ProviderId = @ProviderId";
        connection.Execute(sql, new { ProviderId = providerId });
    }

    public async Task AddProviderAsync(Provider provider)
    {
        using var connection = new SqliteConnection(_databaseConfig.Name);
        await connection.OpenAsync();

      const string sql = @"
    INSERT INTO Providers (
        ProviderId, OrganisationType, OwnershipType, Type, Name,
        BrandId, BrandName, RegistrationStatus, RegistrationDate, CompaniesHouseNumber,
        CharityNumber, Website, PostalAddressLine1, PostalAddressLine2, PostalAddressTownCity,
        PostalAddressCounty, Region, PostalCode, Uprn, OnspdLatitude, OnspdLongitude,
        MainPhoneNumber, InspectionDirectorate, Constituency, LocalAuthority,
        LastInspectionDate, CacheExpiration
    )
    VALUES (
        @ProviderId, @OrganisationType, @OwnershipType, @Type, @Name,
        @BrandId, @BrandName, @RegistrationStatus, @RegistrationDate, @CompaniesHouseNumber,
        @CharityNumber, @Website, @PostalAddressLine1, @PostalAddressLine2, @PostalAddressTownCity,
        @PostalAddressCounty, @Region, @PostalCode, @Uprn, @OnspdLatitude, @OnspdLongitude,
        @MainPhoneNumber, @InspectionDirectorate, @Constituency, @LocalAuthority,
        @LastInspectionDate, @CacheExpiration
    )";


        await connection.ExecuteAsync(sql, new
        {
            provider.ProviderId,
            provider.OrganisationType,
            provider.OwnershipType,
            provider.Type,
            provider.Name,
            provider.BrandId,
            provider.BrandName,
            provider.RegistrationStatus,
            provider.RegistrationDate,
            provider.CompaniesHouseNumber,
            provider.CharityNumber,
            provider.Website,
            provider.PostalAddressLine1,
            provider.PostalAddressLine2,
            provider.PostalAddressTownCity,
            provider.PostalAddressCounty,
            provider.Region,
            provider.PostalCode,
            provider.Uprn,
            provider.OnspdLatitude,
            provider.OnspdLongitude,
            provider.MainPhoneNumber,
            provider.InspectionDirectorate,
            provider.Constituency,
            provider.LocalAuthority,
            LastInspectionDate = provider.LastInspection?.Date,
            provider.CacheExpiration
        });
    }
}