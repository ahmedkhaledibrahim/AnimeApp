using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Update
{
    public class UpdateAnimeShowHandler : IRequestHandler<UpdateAnimeShowCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAnimeShowHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateAnimeShowCommand request, CancellationToken cancellationToken)
        {
            try {

                var animeShow = await _unitOfWork.AnimeShows.GetByIdAsync(request.Id);
                if (animeShow == null)
                {
                    throw new ArgumentException($"No Anime Show found with ID: {request.Id}");
                }
                var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId);
                if (category == null)
                {
                    throw new ArgumentException($"No Category found with ID: {request.CategoryId}");
                }

                animeShow.Title = request.Title;
                animeShow.CategoryId = request.CategoryId;
                animeShow.Rating = request.Rating;
                animeShow.Description = request.Description;
                animeShow.ReleaseDate = request.ReleaseDate;
                animeShow.ImageUrl = request.ImageUrl;

                await _unitOfWork.AnimeShows.UpdateAsync(animeShow);

                await _unitOfWork.SaveChangesAsync();

                return true;
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
