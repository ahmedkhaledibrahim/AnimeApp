using AnimeApp.Application.MediatrGenerics;
using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using Ardalis.Result;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace AnimeApp.Application.Features.AnimeShows.Commands.CreateWithGenericAndResult
{
    public class CreateAnimeShowHandlerWithGR
        : ICommandHandler<AnimeShow,CreateAnimeShowCommandWithGR, int>
    {
       
        private readonly IValidator<CreateAnimeShowCommandWithGR> _validator;
        public CreateAnimeShowHandlerWithGR(IValidator<CreateAnimeShowCommandWithGR> validator, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork,mapper)
        {
            _validator = validator;
        }

        public override async Task<Result<int>> Handle(CreateAnimeShowCommandWithGR request, CancellationToken cancellationToken)
        {
            try {
                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Invalid(validationErrors: validationResult.Errors.Select(e => new ValidationError
                    {
                        ErrorCode = e.ErrorCode,
                        ErrorMessage = e.ErrorMessage,
                        Identifier = e.PropertyName
                    }).ToList());
                }
                var animeShow = _mapper.Map<AnimeShow>(request);

                await _unitOfWork.GetRepository<AnimeShow>().AddAsync(animeShow);
                await _unitOfWork.SaveChangesAsync();

                return Result.Success<int>(animeShow.Id);
            }
            catch (Exception ex) { 
                return Result.Error(errorMessage: ex.Message);
            }
            
        }
    }
}
