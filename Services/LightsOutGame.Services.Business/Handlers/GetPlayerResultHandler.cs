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
    public class GetPlayerResultHandler : IRequestHandler<GetPlayerResultsQuery, IEnumerable<PlayerResponse>>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public GetPlayerResultHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerResponse>> Handle(GetPlayerResultsQuery request, CancellationToken cancellationToken)
        {
            var players = await _playerRepository.GetPlayerResults();
            var response = _mapper.Map<IEnumerable<PlayerResponse>>(players);
            return response;
        }
    }
}
