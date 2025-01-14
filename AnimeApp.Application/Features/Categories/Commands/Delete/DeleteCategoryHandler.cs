using AnimeApp.Application.Features.AnimeShows.Commands.Delete;
using AnimeApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);
                if (category == null)
                {
                    throw new ArgumentException($"No Category found with ID: {request.Id}");
                }
                await _unitOfWork.Categories.DeleteByIdAsync(request.Id);
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
