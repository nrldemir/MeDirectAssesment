using LightsOutGame.Services.Business.Commands.PlayerCreate;
using LightsOutGame.Services.Business.Commands.PlayerUpdate;
using LightsOutGame.Services.Business.Queries;
using LightsOutGame.Services.Business.Responses;
using LightsOutGame.Sheared.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LightsOutGame.Services.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LightsOutGameController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LightsOutGameController> _logger;

        public LightsOutGameController(IMediator mediator, ILogger<LightsOutGameController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlayerResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<PlayerResponse>>> GetPlayerResults()
        {
            var query = new GetPlayerResultsQuery();
            var settings = await _mediator.Send(query);
            if (settings.Count().Equals(0))
                return NotFound();

            return Ok(settings);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SettingResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<SettingResponse>>> GetGameSettings()
        {
            var query = new GetGameSettingQuery();
            var settings = await _mediator.Send(query);
            if (settings.Count().Equals(0))
                return NotFound();

            return Ok(settings);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<PlayerResponse>> NewPlayer([FromBody] PlayerCreateCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<BaseResponse>> GameOver([FromBody] PlayerUpdateCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return NotFound();

            return Ok(result);
        }
    }
}
