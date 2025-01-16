using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Update
{
    public class UpdateAnimeShowCommand : IRequest<bool>
    {
        [Required(ErrorMessage = "Id is required")]

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Rate is required")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "Category Id is required")]
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
