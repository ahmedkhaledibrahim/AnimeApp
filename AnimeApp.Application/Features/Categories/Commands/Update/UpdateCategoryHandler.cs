using AnimeApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Categories.Commands.Update
{

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);

                if (category == null)
                {
                    throw new ArgumentException($"No Category found with ID: {request.Id}");
                }

                category.Description = request.Description;
                category.Name = request.Name;

                await _unitOfWork.Categories.UpdateAsync(category);

                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (ArgumentException ex)
            {
                return false;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while processing your request. Please try again later.", ex);
            }
        }
    }
}
