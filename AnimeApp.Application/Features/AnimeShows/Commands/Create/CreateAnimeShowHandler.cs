using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Create
{
    public class CreateAnimeShowHandler : IRequestHandler<CreateAnimeShowCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAnimeShowHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        

        public async Task<int> Handle(CreateAnimeShowCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId);

                if (category == null)
                {
                    throw new ArgumentException($"Category With ID : {request.CategoryId} Not Found");
                }
                var animeShow = _mapper.Map<AnimeShow>(request);

                await _unitOfWork.AnimeShows.AddAsync(animeShow);

                await _unitOfWork.SaveChangesAsync();
                return animeShow.Id;
            }
            catch (ArgumentException ex) {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while processing your request. Please try again later.", ex);
            }

        }
    }
}
