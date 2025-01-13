using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Commands.Create
{
    public class CreateCastCommand : IRequest<int>
    {   
        public string Name { get; set; }
        public int AnimeShowId { get; set; }
    }
}
