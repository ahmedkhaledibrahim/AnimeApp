using AnimeApp.Application.DTOs;
using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories =  _unitOfWork.Categories.GetAllAsync();
                var items = categories.ToList();
                return _mapper.Map<IEnumerable<CategoryDTO>>(items);

            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}
