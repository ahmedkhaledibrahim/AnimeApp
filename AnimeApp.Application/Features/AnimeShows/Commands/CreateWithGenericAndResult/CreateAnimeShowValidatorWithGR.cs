using FluentValidation;

namespace AnimeApp.Application.Features.AnimeShows.Commands.CreateWithGenericAndResult
{
    public class CreateAnimeShowValidatorWithGR : AbstractValidator<CreateAnimeShowCommandWithGR>
    {
        public CreateAnimeShowValidatorWithGR()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);
            RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0);

            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
