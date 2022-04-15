using LightsOutGame.Client.App.Models;
using LightsOutGame.Sheared.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightsOutGame.Client.App.InterfaceApi
{
    public interface IGameServiceApi_
    {
        Task<IEnumerable<SettingResponse>> GetGameSettings();
        Task<BaseResponse> NewPlayer(NewPlayerViewModel newPlayerViewModel);
        Task<BaseResponse> GameOver(GameoverViewModel gameoverViewModel);
    }
}
