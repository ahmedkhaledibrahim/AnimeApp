using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingCategory = await _unitOfWork.Categories.GetByPropertyValueAsync("Name", request.Name);

                if (existingCategory != null)
                {
                    throw new ValidationException("There is category with the same name");
                }
                var category = _mapper.Map<Category>(request);

                await _unitOfWork.Categories.AddAsync(category);

                await _unitOfWork.SaveChangesAsync();
                
                return category.Id;
            }
            catch (ValidationException ex)
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
