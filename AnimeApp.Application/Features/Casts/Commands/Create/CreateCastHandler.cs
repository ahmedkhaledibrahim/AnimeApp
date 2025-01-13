using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Commands.Create
{
    public class CreateCastHandler : IRequestHandler<CreateCastCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCastHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            try {
                var animeShow = await _unitOfWork.AnimeShows.GetByIdAsync(request.AnimeShowId);
                if (animeShow == null)
                {
                    throw new ArgumentException($"Anime Show With ID : {request.AnimeShowId} Not Found");
                }
                var cast = _mapper.Map<Cast>(request);

                await _unitOfWork.Casts.AddAsync(cast);

                await _unitOfWork.SaveChangesAsync();

                return cast.Id;
            }
            catch (ArgumentException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while processing your request. Please try again later.", ex);
            }
        }
    }
}
