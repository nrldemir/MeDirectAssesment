using AutoMapper;
using LightsOutGame.Data.Domain.Entities;
using LightsOutGame.Data.Domain.Repositories;
using LightsOutGame.Services.Business.Commands.PlayerUpdate;
using LightsOutGame.Sheared.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LightsOutGame.Services.Business.Handlers
{
    public class UpdatePlayerHandler : IRequestHandler<PlayerUpdateCommand, BaseResponse>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public UpdatePlayerHandler(IPlayerRepository playerRepository,IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(PlayerUpdateCommand request, CancellationToken cancellationToken)
        {
            var playerEntity = _mapper.Map<Player>(request);
            if (playerEntity == null)
                throw new ApplicationException("Entity could not be mapped!");

            var result = await _playerRepository.UpdatePlayer(playerEntity);
            return new BaseResponse() { IsSuccess = result };
        }
    }
}
