using Dapper;
using Microsoft.Data.Sqlite;

[module: DapperAot]

namespace Jargar.SchemeServe.Connector.Api.Apis.Db;

public interface IDatabaseBootstrap
{
    void Setup();
}

public class DatabaseBootstrap : IDatabaseBootstrap
{
    private readonly DatabaseConfig _databaseConfig;

    public DatabaseBootstrap(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public void Setup()
    {
        using var connection = new SqliteConnection(_databaseConfig.Name);

        var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Providers';");
        var tableName = table.FirstOrDefault();
        if (!string.IsNullOrEmpty(tableName) && tableName == "Providers")
            return;

        connection.Execute(@"
            CREATE TABLE Providers (
                ProviderId VARCHAR(255) PRIMARY KEY,
                OrganisationType TEXT,
                OwnershipType TEXT,
                Type TEXT,
                Name TEXT,
                BrandId TEXT,
                BrandName TEXT,
                RegistrationStatus TEXT,
                RegistrationDate DATETIME,
                CompaniesHouseNumber TEXT,
                CharityNumber TEXT,
                Website TEXT,
                PostalAddressLine1 TEXT,
                PostalAddressLine2 TEXT,
                PostalAddressTownCity TEXT,
                PostalAddressCounty TEXT,
                Region TEXT,
                PostalCode TEXT,
                Uprn TEXT,
                OnspdLatitude REAL,
                OnspdLongitude REAL,
                MainPhoneNumber TEXT,
                InspectionDirectorate TEXT,
                Constituency TEXT,
                LocalAuthority TEXT,
                LastInspectionDate DATETIME,
                CacheExpiration DATETIME
            );");
    }
}