using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Course.Commands.DeleteCourse;

public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
{
    public DeleteCourseCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Course ID is required.");
    }
}
