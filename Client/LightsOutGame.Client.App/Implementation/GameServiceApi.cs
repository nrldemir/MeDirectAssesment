using LightsOutGame.Client.App.InterfaceApi;
using LightsOutGame.Client.App.Models;
using LightsOutGame.Sheared.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Client.App.Implementation
{
    public class GameServiceApi  //: IGameServiceApi
    {
        public GameServiceApi()
        {
            ApiCallHelper.baseUri = "https://localhost:5001";
        }

        public async Task<IEnumerable<SettingResponse>> GetGameSettings()
        {
            var response = await ApiCallHelper.GetAsync<IEnumerable<SettingResponse>>("/api/LightsOutGame/GetGameSettings", string.Empty, null);
            return response;
        }

        public async Task<BaseResponse> GameOver(GameoverViewModel gameoverViewModel)
        {
            var response = await ApiCallHelper.PostAsync<BaseResponse, GameoverViewModel>("/api/LightsOutGame/GameOver", gameoverViewModel, string.Empty);
            return response;
        }

        public async Task<PlayerResponse> NewPlayer(NewPlayerViewModel newPlayerViewModel)
        {
            var response = await ApiCallHelper.PostAsync<PlayerResponse, NewPlayerViewModel>("/api/LightsOutGame/NewPlayer", newPlayerViewModel, string.Empty);
            return response;
        }
    }
}
