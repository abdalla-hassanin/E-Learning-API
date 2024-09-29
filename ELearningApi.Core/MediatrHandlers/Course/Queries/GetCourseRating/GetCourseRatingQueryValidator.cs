using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseRating;

public class GetCourseRatingQueryValidator : AbstractValidator<GetCourseRatingQuery>
{
    public GetCourseRatingQueryValidator()
    {
        RuleFor(x => x.CourseId).NotEmpty().WithMessage("Course ID is required");
    }
}
