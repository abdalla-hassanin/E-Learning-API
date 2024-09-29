using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.StartQuizAttempt;

public class StartQuizAttemptCommandValidator : AbstractValidator<StartQuizAttemptCommand>
{
    public StartQuizAttemptCommandValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.")
            .Must(BeValidGuid).WithMessage("Invalid Student ID format.");

        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("Quiz ID is required.")
            .Must(BeValidGuid).WithMessage("Invalid Quiz ID format.");
    }

    private bool BeValidGuid(Guid id)
    {
        return id != Guid.Empty;
    }
}
