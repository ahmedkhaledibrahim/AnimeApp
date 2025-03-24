using AnimeApp.Application.MediatrGenerics;
using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using Ardalis.Result;
using AutoMapper;
using FluentValidation;

namespace AnimeApp.Application.Features.AnimeShows.Commands.CreateWithGenericAndResult
{
    public class CreateAnimeShowHandlerWithGR : ICommandHandler<CreateAnimeShowCommandWithGR, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAnimeShowCommandWithGR> _validator;

        public CreateAnimeShowHandlerWithGR(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateAnimeShowCommandWithGR> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Result<int>> Handle(CreateAnimeShowCommandWithGR request, CancellationToken cancellationToken)
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

                await _unitOfWork.AnimeShows.AddAsync(animeShow);
                await _unitOfWork.SaveChangesAsync();

                return Result.Success<int>(animeShow.Id);
            } catch (Exception ex) { 
                return Result.Error(errorMessage: ex.Message);
            }
            
        }
    }
}
