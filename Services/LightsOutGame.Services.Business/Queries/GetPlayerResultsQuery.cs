using LightsOutGame.Sheared.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Services.Business.Queries
{
    public class GetPlayerResultsQuery : IRequest<IEnumerable<PlayerResponse>>
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public string BoardSize { get; set; }
        //public bool IsWinned { get; set; }
    }
}
