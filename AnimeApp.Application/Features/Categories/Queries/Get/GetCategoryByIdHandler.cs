using AnimeApp.Application.DTOs;
using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Categories.Queries.Get
{
    

    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
           
            try {
                var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);
                
                if (category == null)
                {
                    throw new ArgumentException($"No Category found with ID: {request.Id}");
                }
                var categoryAnimeShows =  _unitOfWork.AnimeShows.GetAllAsync().Where(a => a.CategoryId == request.Id).ToList();

                category.AnimeShows = categoryAnimeShows;

                return _mapper.Map<CategoryDTO>(category);

            }
            catch (ArgumentException ex)
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
