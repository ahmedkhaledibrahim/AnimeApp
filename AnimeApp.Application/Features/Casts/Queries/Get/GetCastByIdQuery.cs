using AnimeApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Queries.Get
{
    public class GetCastByIdQuery : IRequest<CastDTO>
    {
        [Required(ErrorMessage = "Id is required")]

        public int Id { get; set; }
    }
}
