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

namespace AnimeApp.Application.Features.Casts.Queries.Get
{
    public class GetCastByIdHandler : IRequestHandler<GetCastByIdQuery, CastDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCastByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CastDTO> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cast = await _unitOfWork.GetRepository<Cast>().GetByIdAsync(request.Id);
                if (cast == null)
                {
                    throw new ArgumentException($"No Cast found with ID: {request.Id}");
                }
                return _mapper.Map<CastDTO>(cast);
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
