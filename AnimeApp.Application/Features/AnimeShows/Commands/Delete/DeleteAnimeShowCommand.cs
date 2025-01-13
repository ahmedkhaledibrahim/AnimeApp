using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Delete
{
    public class DeleteAnimeShowCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
