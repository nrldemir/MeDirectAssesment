using AutoMapper;
using LightsOutGame.Data.Domain.Repositories;
using LightsOutGame.Services.Business.Queries;
using LightsOutGame.Sheared.Common.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LightsOutGame.Services.Business.Handlers
{
    public class GetGameSettingHandler : IRequestHandler<GetGameSettingQuery, IEnumerable<SettingResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetGameSettingHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SettingResponse>> Handle(GetGameSettingQuery request, CancellationToken cancellationToken)
        {
            var settingList = await _gameRepository.GetGameSettings();
            var response = _mapper.Map<IEnumerable<SettingResponse>>(settingList);
            return response;
        }
    }
}
