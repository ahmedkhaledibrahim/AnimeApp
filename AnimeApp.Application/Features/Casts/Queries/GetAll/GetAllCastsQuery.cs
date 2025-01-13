using AnimeApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Queries.GetAll
{
    public class GetAllCastsQuery : IRequest<IEnumerable<CastDTO>>
    {
    }
}
