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
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(LightsOutGameDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Player>> GetPlayerResults()
        {
            var result = await GetAllAsync();
            return result;
        }

        public async Task<Player> NewPlayer(Player player)
        {
            var result = await AddAsync(player);
            return result;
        }

        public async Task<bool> UpdatePlayer(Player player)
        {
            var tmpPlayer = await GetByIdAsync(player.Id);
            if (tmpPlayer == null)
                return false;
            else
                tmpPlayer.IsWinned = true;

            var result = await UpdateAsync(tmpPlayer);
            if (!result.Equals(0))
                return true;
            else
                return false;
        }
    }
}
