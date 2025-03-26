using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Commands.Update
{
    public class UpdateCastHandler : IRequestHandler<UpdateCastCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UpdateCastHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }
        public async Task<bool> Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            try {
                var cast = await _unitOfWork.GetRepository<Cast>().GetByIdAsync(request.Id);
                if (cast == null)
                {
                    throw new ArgumentException($"No Cast found with ID: {request.Id}");
                }
                var animeShow = await _unitOfWork.GetRepository<AnimeShow>().GetByIdAsync(request.AnimeShowId);
                if (animeShow == null)
                {
                    throw new ArgumentException($"No Anime Show found with ID: {request.Id}");
                }

                cast.Name = request.Name;
                cast.AnimeShowId = request.AnimeShowId;

                await _unitOfWork.GetRepository<Cast>().UpdateAsync(cast);
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
