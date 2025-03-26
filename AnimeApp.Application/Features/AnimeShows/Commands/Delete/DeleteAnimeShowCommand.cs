using AnimeApp.Application.MediatrGenerics;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Delete
{
    public class DeleteAnimeShowCommand : ICommand<bool>
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
    }
}
