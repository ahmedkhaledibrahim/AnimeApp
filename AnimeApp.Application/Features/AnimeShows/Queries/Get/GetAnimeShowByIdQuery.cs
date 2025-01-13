using AnimeApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Queries.Get
{
    public class GetAnimeShowByIdQuery : IRequest<AnimeShowDTO>
    {
        public int Id { get; set; }
    }
}
