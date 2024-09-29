using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewsForCourse;

public class GetReviewsForCourseQueryValidator : AbstractValidator<GetReviewsForCourseQuery>
{
    public GetReviewsForCourseQueryValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Invalid Course ID.");

        RuleFor(x => x.Page)
            .GreaterThan(0).WithMessage("Page number must be greater than 0.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100).WithMessage("Page size must be between 1 and 100.");
    }
}
