using AnimeApp.Application.DTOs;
using AnimeApp.Domain.Common;
using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Queries.GetAll
{
    public class GetAllAnimeShowsHandler : IRequestHandler<GetAllAnimeShowsQuery, PaginatedResult<BaseAnimeShowDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAnimeShowsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<BaseAnimeShowDTO>> Handle(GetAllAnimeShowsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var animeShows =  _unitOfWork.AnimeShows.GetAll();

                if (!string.IsNullOrEmpty(request.Title))
                {
                    animeShows = animeShows.Where(a => a.Title.ToLower().Contains(request.Title.ToLower()));
                }
                if (request.MinimumRate != null && request.MinimumRate > 0.0)
                {
                    animeShows = animeShows.Where(a => a.Rating > request.MinimumRate);
                }
                if (request.CategoryId != null)
                {
                    animeShows = animeShows.Where(a => a.CategoryId == request.CategoryId);
                }

                var totalCount = animeShows.Count();

                // Apply pagination
                var items = animeShows
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                return new PaginatedResult<BaseAnimeShowDTO>()
                {
                    Items = _mapper.Map<IEnumerable<BaseAnimeShowDTO>>(items),
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    TotalCount = totalCount,
                };
            }
            catch (Exception ex) {
                throw;
            }
            
        }
    }
}
