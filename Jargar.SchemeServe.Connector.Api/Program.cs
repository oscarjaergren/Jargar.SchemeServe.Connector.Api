using Jargar.SchemeServe.Connector.Api.Apis;
using Jargar.SchemeServe.Connector.Api.Apis.Db;
using Jargar.SchemeServe.Connector.Api.Apis.Db.Repository;
using Jargar.SchemeServe.Connector.Api.Apis.ProviderService;
using Jargar.SchemeServe.Connector.Api.DataContract;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, ProviderContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, ApiProvidersResponseContext.Default);
});

builder.Services.AddHttpClient("ProviderClient", client => client.BaseAddress = new Uri("https://api.cqc.org.uk/public/v1/"));

var database = new DatabaseConfig() { Name = builder.Configuration["LocalDb"] };
var dbBootStrap = new DatabaseBootstrap(database);
dbBootStrap.Setup();

builder.Services.AddSingleton(database);

builder.Services.AddScoped<IProviderService, ProviderService>();

builder.Services.AddScoped<IProviderRepository, ProviderRepository>();

WebApplication app = builder.Build();

app.MapConnectorApi();
app.UseHttpsRedirection();

app.Run();

//Added so we can access this for the purpose of Unit Tests
public partial class Program { }