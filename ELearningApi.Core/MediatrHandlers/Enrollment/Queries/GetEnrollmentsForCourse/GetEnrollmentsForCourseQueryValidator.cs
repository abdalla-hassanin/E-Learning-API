using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentsForCourse;

public class GetEnrollmentsForCourseQueryValidator : AbstractValidator<GetEnrollmentsForCourseQuery>
{
    public GetEnrollmentsForCourseQueryValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");
    }
}

