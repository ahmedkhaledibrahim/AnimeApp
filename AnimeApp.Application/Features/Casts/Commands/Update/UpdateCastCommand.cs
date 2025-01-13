using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Commands.Update
{
    public class UpdateCastCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimeShowId { get; set; }
    }
}
