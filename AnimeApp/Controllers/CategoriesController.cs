using AnimeApp.Application.DTOs;
using AnimeApp.Application.Features.AnimeShows.Commands.Create;
using AnimeApp.Application.Features.AnimeShows.Commands.Delete;
using AnimeApp.Application.Features.AnimeShows.Commands.Update;
using AnimeApp.Application.Features.AnimeShows.Queries.Get;
using AnimeApp.Application.Features.AnimeShows.Queries.GetAll;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<CategoryDTO>>> GetCategories(
           [FromQuery] GetAllCategoriesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("CategoryById")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(
            [FromQuery] GetCategoryByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateCategory([FromBody] CreateCategoryCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<bool>> UpdateCategory([FromBody] UpdateCategoryCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> DeleteCategory([FromQuery] DeleteCategoryCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
