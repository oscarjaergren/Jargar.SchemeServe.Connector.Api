using Jargar.SchemeServe.Connector.Api.Apis;
using Jargar.SchemeServe.Connector.Api.Apis.Db;
using Jargar.SchemeServe.Connector.Api.Apis.Db.Repository;
using Jargar.SchemeServe.Connector.Api.Apis.ProviderService;
using Jargar.SchemeServe.Connector.Api.DataContract;
using Microsoft.EntityFrameworkCore;
using MyCompiledModels;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.TypeInfoResolverChain.Insert(0, ProviderContext.Default));

builder.Services.AddHttpClient("ProviderClient", client => client.BaseAddress = new Uri("https://api.cqc.org.uk/public/v1/"));

builder.Services.AddScoped<IProviderService, ProviderService>();

builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddDbContext<ProviderDbContext>(options => options.UseSqlite(builder.Configuration["LocalDb"]).UseModel(ProviderDbContextModel.Instance));

WebApplication app = builder.Build();

app.MapConnectorApi();
app.UseHttpsRedirection();

app.Run();

//Added so we can access this for the purpose of Unit Tests
public partial class Program { }