using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.SearchCourses;

public class SearchCoursesQueryValidator : AbstractValidator<SearchCoursesQuery>
{
    public SearchCoursesQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Page number must be greater than 0");
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100).WithMessage("Page size must be between 1 and 100");
        RuleFor(x => x.SearchTerm).MaximumLength(100).WithMessage("Search term cannot exceed 100 characters");
        When(x => x.CategoryId.HasValue, () => 
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID cannot be empty");
        });
    }
}
