﻿using AnimeApp.Application.DTOs;
using AnimeApp.Application.Features.AnimeShows.Commands.Create;
using AnimeApp.Application.Features.AnimeShows.Commands.Delete;
using AnimeApp.Application.Features.AnimeShows.Commands.Update;
using AnimeApp.Application.Features.AnimeShows.Queries.Get;
using AnimeApp.Application.Features.AnimeShows.Queries.GetAll;
using AnimeApp.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AnimeShowsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimeShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<AnimeShowDTO>>> GetAnimeShows(
            [FromQuery] GetAllAnimeShowsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("AnimeShowById")]
        public async Task<ActionResult<AnimeShowDTO>> GetAnimeShowById(
            [FromQuery] GetAnimeShowByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateAnimeShow([FromBody] CreateAnimeShowCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<bool>> UpdateAnimeShow([FromBody] UpdateAnimeShowCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> DeleteAnimeShow([FromBody] DeleteAnimeShowCommand query) {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}