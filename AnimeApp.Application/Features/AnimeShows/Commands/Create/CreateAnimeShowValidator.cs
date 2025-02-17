using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Create
{
    public class CreateAnimeShowValidator : AbstractValidator<CreateAnimeShowCommand>
    {
        public CreateAnimeShowValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
