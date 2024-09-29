using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetOverallCourseProgress;

public class GetOverallCourseProgressQueryValidator : AbstractValidator<GetOverallCourseProgressQuery>
{
    public GetOverallCourseProgressQueryValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid Student ID.");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid Course ID.");
    }
}