using AnimeApp.Application.MediatrGenerics;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Update
{
    public class UpdateAnimeShowCommand : ICommand<bool>
    {     
        public int Id { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
