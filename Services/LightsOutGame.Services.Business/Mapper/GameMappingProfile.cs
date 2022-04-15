using AutoMapper;
using LightsOutGame.Data.Domain.Entities;
using LightsOutGame.Services.Business.Commands.PlayerCreate;
using LightsOutGame.Services.Business.Commands.PlayerUpdate;
using LightsOutGame.Sheared.Common.Models;

namespace LightsOutGame.Services.Business.Mapper
{
    public class GameMappingProfile : Profile
    {
        public GameMappingProfile()
        {
            CreateMap<Player, PlayerUpdateCommand>().ReverseMap();
            CreateMap<Player, PlayerCreateCommand>().ReverseMap();
            CreateMap<Player, PlayerResponse>().ReverseMap();
            CreateMap<GameSetting, SettingResponse>().ReverseMap();
        }
    }
}
