using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Update
{
    public sealed class UpdateAnimeShowValidator : AbstractValidator<UpdateAnimeShowCommand>
    {
        public UpdateAnimeShowValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.").MinimumLength(2).WithMessage("Title must be at least 2 characters long.").MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required.").GreaterThan(0).WithMessage("Category ID must be greater than 0.");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Rating is required.").GreaterThan(0).WithMessage("Rating must be greater than 0.");
        }
    }
}
