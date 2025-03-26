using AnimeApp.Application.Features.AnimeShows.Commands.CreateWithGenericAndResult;
using AnimeApp.Application.MediatrGenerics;
using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using Ardalis.Result;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Update
{
    public class UpdateAnimeShowHandler(IValidator<UpdateAnimeShowCommand> _validator, IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<AnimeShow,UpdateAnimeShowCommand, bool>(unitOfWork, mapper)
    {
        
        public override async Task<Result<bool>> Handle(UpdateAnimeShowCommand request, CancellationToken cancellationToken)
        {
            try {
                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result<bool>.Invalid(validationErrors: validationResult.Errors.Select(e => new ValidationError
                    {
                        ErrorCode = e.ErrorCode,
                        ErrorMessage = e.ErrorMessage,
                        Identifier = e.PropertyName
                    }).ToList());
                }
                var animeShow = await unitOfWork.GetRepository<AnimeShow>().GetByIdAsync(request.Id);
                if (animeShow == null)
                {
                    return Result.Invalid(new ValidationError() { 
                      ErrorCode = "NotFound",
                      ErrorMessage = $"No Anime Show found with ID: {request.Id}",
                      Identifier = "Id",
                    });
                }
                var category = await unitOfWork.GetRepository<AnimeShow>().GetByIdAsync(request.CategoryId);
                if (category == null)
                {
                    return Result.Invalid(new ValidationError()
                    {
                        ErrorCode = "NotFound",
                        ErrorMessage = $"No Category found with ID: {request.CategoryId}",
                        Identifier = "Category Id",
                    });
                }

                animeShow.Title = request.Title;
                animeShow.CategoryId = request.CategoryId;
                animeShow.Rating = request.Rating;
                animeShow.Description = request.Description;
                animeShow.ReleaseDate = request.ReleaseDate;
                animeShow.ImageUrl = request.ImageUrl;

                await unitOfWork.GetRepository<AnimeShow>().UpdateAsync(animeShow);

                await unitOfWork.SaveChangesAsync();

                return Result.Success(true);
            }
            catch (ArgumentException ex)
            {
                return Result.Error(ex.Message);

            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
