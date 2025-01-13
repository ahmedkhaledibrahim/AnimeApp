using AnimeApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Categories.Queries.Get
{
    public class GetCategoryByIdQuery : IRequest<CategoryDTO>
    {
        public int Id { get; set; }
    }
}
