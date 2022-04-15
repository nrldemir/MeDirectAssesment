using LightsOutGame.Data.Infrastructure;
using LightsOutGame.Data.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace LightsOutGame.Services.Api.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var gameContext = scope.ServiceProvider.GetRequiredService<LightsOutGameDbContext>();

                    if (gameContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        gameContext.Database.Migrate();
                    }

                    LightsOutGameContextSeed.SeedAsync(gameContext).Wait();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return host;
        }
    }
}
