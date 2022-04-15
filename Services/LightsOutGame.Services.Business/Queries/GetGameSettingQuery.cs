using LightsOutGame.Sheared.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace LightsOutGame.Services.Business.Queries
{
    public class GetGameSettingQuery : IRequest<IEnumerable<SettingResponse>>
    { 
    }
}
