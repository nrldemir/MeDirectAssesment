using LightsOutGame.Data.Domain.Entities;
using LightsOutGame.Data.Domain.Repositories;
using LightsOutGame.Data.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Data.Infrastructure.Repositories
{
    public class GameRepository : Repository<GameSetting>, IGameRepository
    {
        public GameRepository(LightsOutGameDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<GameSetting>> GetGameSettings()
        {
            var gameSettings = await _dbContext.GameSetting.ToListAsync();
            return gameSettings;
        }
    }
}
