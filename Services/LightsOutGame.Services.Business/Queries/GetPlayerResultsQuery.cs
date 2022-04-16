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
    }
}
