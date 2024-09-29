using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetCompletedLectures;

public class GetCompletedLecturesQueryValidator : AbstractValidator<GetCompletedLecturesQuery>
{
    public GetCompletedLecturesQueryValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid Student ID.");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid Course ID.");
    }
}