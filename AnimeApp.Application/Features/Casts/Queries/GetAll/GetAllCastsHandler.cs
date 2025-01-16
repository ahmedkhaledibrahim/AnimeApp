using AnimeApp.Application.DTOs;
using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Queries.GetAll
{
    public class GetAllCastsHandler : IRequestHandler<GetAllCastsQuery, IEnumerable<CastDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCastsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CastDTO>> Handle(GetAllCastsQuery request, CancellationToken cancellationToken)
        {
            try {
                var casts =  _unitOfWork.Casts.GetAll();
                var items = casts.ToList();
                return _mapper.Map<IEnumerable<CastDTO>>(items);

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
