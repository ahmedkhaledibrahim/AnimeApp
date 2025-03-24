using FluentValidation;

namespace AnimeApp.Application.Features.AnimeShows.Commands.CreateWithGenericAndResult
{
    public class CreateAnimeShowCommandWithGRValidator : AbstractValidator<CreateAnimeShowCommandWithGR>
    {
        public CreateAnimeShowCommandWithGRValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
