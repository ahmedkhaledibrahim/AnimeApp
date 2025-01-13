using AnimeApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Queries.Get
{
    public class GetCastByIdQuery : IRequest<CastDTO>
    {
        public int Id { get; set; }
    }
}
