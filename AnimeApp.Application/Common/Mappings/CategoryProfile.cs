using AnimeApp.Application.DTOs;
using AnimeApp.Application.Features.Categories.Commands.Create;
using AnimeApp.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Common.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();     
            CreateMap<Category, CategoryDTO>();     
            CreateMap<CategoryDTO, Category>();     
        }
    }
}
