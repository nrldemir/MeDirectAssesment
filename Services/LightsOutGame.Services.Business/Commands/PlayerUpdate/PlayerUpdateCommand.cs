using LightsOutGame.Sheared.Common.Models;
using MediatR;

namespace LightsOutGame.Services.Business.Commands.PlayerUpdate
{
    public class PlayerUpdateCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public bool IsWinned { get; set; }
    }
}
