using AnimeApp.Application.DTOs;
using AnimeApp.Application.Features.AnimeShows.Commands.Create;
using AnimeApp.Application.Features.AnimeShows.Queries.Get;
using AnimeApp.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Common.Mappings
{
    public class AnimeShowProfile : Profile
    {
        public AnimeShowProfile()
        {
            CreateMap<CreateAnimeShowCommand, AnimeShow>();
            CreateMap<GetAnimeShowByIdQuery, AnimeShowDTO>();
            CreateMap<AnimeShow, AnimeShowDTO>();
            CreateMap<AnimeShow, BaseAnimeShowDTO>();
        }
    }
}
