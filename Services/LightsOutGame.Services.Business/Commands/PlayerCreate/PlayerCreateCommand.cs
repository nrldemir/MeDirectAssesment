using LightsOutGame.Sheared.Common.Models;
using MediatR;

namespace LightsOutGame.Services.Business.Commands.PlayerCreate
{
    public class PlayerCreateCommand : IRequest<PlayerResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BoardSize { get; set; }
        public bool IsWinned { get; set; }
    }
}
