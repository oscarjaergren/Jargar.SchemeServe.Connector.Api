# Connector API
The Connector API is designed to integrate with the CQC (Care Quality Commission) provider API, allowing users to look up providers and individual provider details.

## External API Documentation
Documentation for the CQC provider API can be found [here](https://anypoint.mulesoft.com/exchange/portals/care-quality-commission-5/4d36bd23-127d-4acf-8903-ba292ea615d4/cqc-syndication-1/).
**Note:** This is an unauthenticated API accessible publicly.

## API Endpoints
### 1. Get Providers
GET: https://api.cqc.org.uk/public/v1/providers
### 2. Get Individual Provider
GET: https://api.cqc.org.uk/public/v1/providers/{provider_id}


## Behaviour Requirements
- Records are cached in a database.
- Records have a timeout of one month from being cached.
- Individual requested records are to be individually cached.
- When a request is made, the Connector first checks if the record exists in the cache. If found, the record is returned.
- If not found, the external API is called.
- If a matching record is discovered in the external API, it is cached into the database and then returned.

### Returned Values

The Connector will return the following values (everything else from the external API is dropped):
 ```json
{
"providerId": "1-345678912", 
"locationIds": [ 
 "1-987654321", 
 "1-876543212" 
], 
"organisationType": "Provider", 
"ownershipType": "NHS Body",  
"type": "NHS Healthcare Organisation", 
"name": "Sample Teaching Hospitals NHS Foundation Trust",  
"brandId": "ABC123", 
"brandName": "Sample Hill",  
"registrationStatus": "Registered", 
"registrationDate": "2012-04-01", 
"companiesHouseNumber": "12345678",  
"charityNumber": "123456", 
"website": "www.samplehospitals.nhs.uk", 
"postalAddressLine1": "Trust Headquarters, Example Hospital", 
“postalAddressLine2": "Example Road",
“postalAddressTownCity": "Blackpool", 
"postalAddressCounty": "Lancashire", 
"region": "North West", 
"postalCode": "FY3 8RN", 
"uprn": "123456789012", 
"onspdLatitude": 53.123456, 
"onspdLongitude": -2.123456, 
"mainPhoneNumber": "01253301234", 
"inspectionDirectorate": "Hospitals", 
"constituency": "Blackpool North and Cleveleys", 
"localAuthority": "Blackpool", 
"lastInspection": { 
 "date": "2021-11-01" 
}
   ```

## Test Constraints
The API must be created in .NET 7 (or higher).
Write unit tests using XUnit or any preferred testing framework.
Dapper is used as the .NET database object mapper.
Notes for Self
This project serves as a proof of concept for Native AOT and database support. Efforts have been made to minimize reflection usage, opting for source generators. Native AOT, while evolving, currently suits lightweight use cases.

## Requirements

- .NET 8
- EF framework tools
- ASP.NET Core
- SQLite

## Getting Started

1. Run commands to create the database.
   - Install EF tools using Nuget Package Manager console if not installed:
     ```
     dotnet tool install --global dotnet-ef
     dotnet tool update --global dotnet-ef
     ```
   - Run the following in the terminal:
     dotnet ef database update
     ```

2. Add the database connection string. Example:
   - Right-click the `Jargar.SchemeServe.Connector.Api.CsProj` and select "Manage User Secrets."
   - Input your LocalDB string:
     ```json
     {
       "LocalDb": "Data Source=C:\\Users\\Aorus\\source\\repos\\Jargar.SchemeServe.Connector.Api\\Jargar.SchemeServe.Connector.Api\\My.db"
     }
     ```

## Areas of Improvement

- Lack of integration tests.
- Improve error handling in both the service and repository layers.
