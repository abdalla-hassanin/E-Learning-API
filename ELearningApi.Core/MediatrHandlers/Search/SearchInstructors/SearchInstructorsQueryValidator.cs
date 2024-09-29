using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Search.SearchInstructors;

public class SearchInstructorsQueryValidator : AbstractValidator<SearchInstructorsQuery>
{
    public SearchInstructorsQueryValidator()
    {
        RuleFor(x => x.SearchTerm)
            .NotEmpty().WithMessage("Search term is required.")
            .MaximumLength(100).WithMessage("Search term must not exceed 100 characters.");

        RuleFor(x => x.Expertise)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.Expertise))
            .WithMessage("Expertise must not exceed 50 characters.");
    }
}
