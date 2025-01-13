using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Delete
{
    public class DeleteAnimeShowHandler : IRequestHandler<DeleteAnimeShowCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAnimeShowHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteAnimeShowCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var animeShow = await _unitOfWork.AnimeShows.GetByIdAsync(request.Id);
                if (animeShow == null)
                {
                    throw new ArgumentException($"No Anime Show found with ID: {request.Id}");
                }
                await _unitOfWork.AnimeShows.DeleteByIdAsync(request.Id);
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
