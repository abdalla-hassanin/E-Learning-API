using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UnEnrollStudentFromCourse;

public class UnEnrollStudentFromCourseCommandValidator : AbstractValidator<UnEnrollStudentFromCourseCommand>
{
    public UnEnrollStudentFromCourseCommandValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");
    }
}
