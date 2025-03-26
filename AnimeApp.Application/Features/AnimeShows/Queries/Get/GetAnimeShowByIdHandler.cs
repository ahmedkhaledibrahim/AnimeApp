using AnimeApp.Application.DTOs;
using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Queries.Get
{
    public class GetAnimeShowByIdHandler : IRequestHandler<GetAnimeShowByIdQuery, AnimeShowDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAnimeShowByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AnimeShowDTO> Handle(GetAnimeShowByIdQuery request, CancellationToken cancellationToken)
        {
            try {
                var animeShow = await _unitOfWork.GetRepository<AnimeShow>().GetByIdAsync(request.Id);
                if (animeShow == null)
                {
                    throw new ArgumentException($"No Anime Show found with ID: {request.Id}");
                }
                var animeShowCasts =  _unitOfWork.GetRepository<Cast>().GetAll().Where(c => c.AnimeShowId == animeShow.Id).ToList();
                animeShow.Casts = animeShowCasts;
                return _mapper.Map<AnimeShowDTO>(animeShow);
            }
            catch(ArgumentException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                // Propagate the exception to a global error handler
                throw;
            }

        }
    }
}
