using AnimeApp.Application.Features.AnimeShows.Commands.Delete;
using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Casts.Commands.Delete
{
    public class DeleteCastHandler : IRequestHandler<DeleteCastCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCastHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteCastCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cast = await _unitOfWork.GetRepository<Cast>().GetByIdAsync(request.Id);
                if (cast == null)
                {
                    throw new ArgumentException($"No Cast found with ID: {request.Id}");
                }
                await _unitOfWork.GetRepository<Cast>().DeleteByIdAsync(request.Id);
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
