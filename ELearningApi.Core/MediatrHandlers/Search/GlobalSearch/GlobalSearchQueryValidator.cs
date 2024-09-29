using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Search.GlobalSearch;

public class GlobalSearchQueryValidator : AbstractValidator<GlobalSearchQuery>
{
    public GlobalSearchQueryValidator()
    {
        RuleFor(x => x.SearchTerm)
            .NotEmpty().WithMessage("Search term is required.")
            .MaximumLength(100).WithMessage("Search term must not exceed 100 characters.");
    }
}