using LightsOutGame.Data.Domain.Repositories;
using LightsOutGame.Data.Domain.Repositories.Base;
using LightsOutGame.Data.Infrastructure.Repositories;
using LightsOutGame.Data.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LightsOutGame.Data.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
            //                                    ServiceLifetime.Singleton,
            //                                    ServiceLifetime.Singleton);

            services.AddDbContext<LightsOutGameDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("LightsOutGameConnection"),
                        b => b.MigrationsAssembly(typeof(LightsOutGameDbContext).Assembly.FullName)), ServiceLifetime.Singleton);

            //Add Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            return services;
        }
    }
}
