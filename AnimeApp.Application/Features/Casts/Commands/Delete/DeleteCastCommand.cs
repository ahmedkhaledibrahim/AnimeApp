using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Commands.Delete
{
    public class DeleteCastCommand : IRequest<bool>
    {
        [Required(ErrorMessage = "Id is required")]

        public int Id { get; set; }
    }
}
