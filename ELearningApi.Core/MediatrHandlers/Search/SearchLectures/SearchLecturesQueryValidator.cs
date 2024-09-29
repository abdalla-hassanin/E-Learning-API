using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Search.SearchLectures;

public class SearchLecturesQueryValidator : AbstractValidator<SearchLecturesQuery>
{
    public SearchLecturesQueryValidator()
    {
        RuleFor(x => x.SearchTerm)
            .NotEmpty().WithMessage("Search term is required.")
            .MaximumLength(100).WithMessage("Search term must not exceed 100 characters.");
    }
}
