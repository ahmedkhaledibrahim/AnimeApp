using AnimeApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Queries.Get
{
    public class GetAnimeShowByIdQuery : IRequest<AnimeShowDTO>
    {
        [Required(ErrorMessage = "Id is required")]

        public int Id { get; set; }
    }
}
