using AutoMapper;
using LightsOutGame.Data.Domain.Entities;
using LightsOutGame.Data.Domain.Repositories;
using LightsOutGame.Services.Business.Commands.PlayerCreate;
using LightsOutGame.Sheared.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LightsOutGame.Services.Business.Handlers
{
    public class CreatePlayerHandler : IRequestHandler<PlayerCreateCommand, PlayerResponse>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public CreatePlayerHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<PlayerResponse> Handle(PlayerCreateCommand request, CancellationToken cancellationToken)
        {
            var playerEntity = _mapper.Map<Player>(request);
            if (playerEntity == null)
                throw new ApplicationException("Entity could not be mapped!");

            var result = await _playerRepository.NewPlayer(playerEntity);
            var tmpMapped = _mapper.Map<PlayerResponse>(result);
            return tmpMapped;
        }
    }
}
