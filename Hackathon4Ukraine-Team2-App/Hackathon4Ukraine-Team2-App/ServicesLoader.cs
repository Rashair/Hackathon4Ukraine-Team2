using Microsoft.EntityFrameworkCore.Cosmos.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using Hackathon4Ukraine_Team2_App.DataAccess;
using Hackathon4Ukraine_Team2_App.Domain;

namespace Hackathon4Ukraine_Team2_App;

public static class ServicesLoader
{
    public static void AddAllServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddRazorPages();
        services.AddServerSideBlazor();

        var configuration = builder.Configuration;

        services.Configure<CosmosSettings>(
               configuration.GetSection(nameof(CosmosSettings)));
        services.AddDbContextFactory<AppDbContext>(
           (IServiceProvider sp, DbContextOptionsBuilder opts) =>
           {
               var cosmosSettings = sp
                   .GetRequiredService<IOptions<CosmosSettings>>()
                   .Value;

               opts.UseCosmos(
                   cosmosSettings.Endpoint,
                   cosmosSettings.AccessKey,
                   nameof(AppDbContext));
           });

        services.AddSingleton<IRequestHelpService, RequestHelpService>();
    }
}

