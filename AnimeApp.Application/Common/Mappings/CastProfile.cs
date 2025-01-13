using AnimeApp.Application.DTOs;
using AnimeApp.Application.Features.Casts.Commands.Create;
using AnimeApp.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Common.Mappings
{
    public class CastProfile : Profile
    {
        public CastProfile()
        {
            CreateMap<CreateCastCommand, Cast>();    
            CreateMap<Cast, CastDTO>();    
            CreateMap<CastDTO, Cast>();    
        }
    }
}
