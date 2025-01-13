using AnimeApp.Application.DTOs;
using AnimeApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Queries.GetAll
{
    public class GetAllAnimeShowsQuery : IRequest<PaginatedResult<AnimeShowDTO>>
    {
        public int? CategoryId { get; set; }
        public string? Title { get; set; }
        public double? MinimumRate { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
