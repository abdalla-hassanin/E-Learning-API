using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Search.SearchCourses;

public class SearchCoursesQueryValidator : AbstractValidator<SearchCoursesQuery>
{
    public SearchCoursesQueryValidator()
    {
        RuleFor(x => x.SearchTerm)
            .NotEmpty().WithMessage("Search term is required.")
            .MaximumLength(100).WithMessage("Search term must not exceed 100 characters.");

        RuleFor(x => x.MinPrice)
            .GreaterThanOrEqualTo(0).When(x => x.MinPrice.HasValue)
            .WithMessage("Minimum price must be greater than or equal to 0.");

        RuleFor(x => x.MaxPrice)
            .GreaterThan(x => x.MinPrice).When(x => x.MinPrice.HasValue && x.MaxPrice.HasValue)
            .WithMessage("Maximum price must be greater than the minimum price.");
    }
}
