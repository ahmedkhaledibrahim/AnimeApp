using AnimeApp.Application.MediatrGenerics;
using Ardalis.Result;
using System.ComponentModel.DataAnnotations;

namespace AnimeApp.Application.Features.AnimeShows.Commands.CreateWithGenericAndResult
{
    public class CreateAnimeShowCommandWithGR : ICommand<int>
    {
        public string Title { get; set; }
        public double Rating { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
