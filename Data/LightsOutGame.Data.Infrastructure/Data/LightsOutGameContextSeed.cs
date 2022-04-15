using LightsOutGame.Data.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LightsOutGame.Data.Infrastructure.Data
{
    public class LightsOutGameContextSeed
    {
        public static async Task SeedAsync(LightsOutGameDbContext lightsOutGameDbContext)
        {
            if (!lightsOutGameDbContext.GameSetting.Any())
            {
                _ = lightsOutGameDbContext.GameSetting.AddRangeAsync(GetPreconfiguredSettings());
                await lightsOutGameDbContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<GameSetting> GetPreconfiguredSettings()
        {
            return new List<GameSetting>()
            {
               new GameSetting()
               {
                   BoardSizeX = 4,
                   BoardSizeY = 4
               },
               new GameSetting()
               {
                   BoardSizeX = 5, 
                   BoardSizeY = 5
               },
               new GameSetting()
               {
                   BoardSizeX = 8,
                   BoardSizeY = 8
               },
               new GameSetting()
               {
                   BoardSizeX = 10,
                   BoardSizeY = 10
               }
            };
        }
    }

}
