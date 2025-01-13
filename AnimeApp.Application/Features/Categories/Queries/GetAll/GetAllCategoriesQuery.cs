using AnimeApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDTO>>
    {
    }
}
