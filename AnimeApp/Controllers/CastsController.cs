using AnimeApp.Application.DTOs;
using AnimeApp.Application.Features.Casts.Commands.Create;
using AnimeApp.Application.Features.Casts.Commands.Delete;
using AnimeApp.Application.Features.Casts.Commands.Update;
using AnimeApp.Application.Features.Casts.Queries.Get;
using AnimeApp.Application.Features.Casts.Queries.GetAll;
using AnimeApp.Application.Features.Categories.Commands.Create;
using AnimeApp.Application.Features.Categories.Commands.Delete;
using AnimeApp.Application.Features.Categories.Commands.Update;
using AnimeApp.Application.Features.Categories.Queries.Get;
using AnimeApp.Application.Features.Categories.Queries.GetAll;
using AnimeApp.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<CastDTO>>> GetCasts(
           [FromQuery] GetAllCastsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("CastById")]
        public async Task<ActionResult<CastDTO>> GetCastById(
            [FromQuery] GetCastByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateCast([FromBody] CreateCastCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<bool>> UpdateCast([FromBody] UpdateCastCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> DeleteCast([FromQuery] DeleteCastCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
