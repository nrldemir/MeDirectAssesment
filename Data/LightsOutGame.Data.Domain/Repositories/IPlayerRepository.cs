using LightsOutGame.Data.Domain.Entities;
using LightsOutGame.Data.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Data.Domain.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<IEnumerable<Player>> GetPlayerResults();
        Task<Player> NewPlayer(Player player);
        Task<bool> UpdatePlayer(Player player);
    }
}
