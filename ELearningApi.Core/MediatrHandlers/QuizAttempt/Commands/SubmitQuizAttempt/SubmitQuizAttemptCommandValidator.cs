using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.SubmitQuizAttempt;

public class SubmitQuizAttemptCommandValidator : AbstractValidator<SubmitQuizAttemptCommand>
{
    public SubmitQuizAttemptCommandValidator()
    {
        RuleFor(x => x.AttemptId)
            .NotEmpty().WithMessage("Attempt ID is required.")
            .Must(BeValidGuid).WithMessage("Invalid Attempt ID format.");

        RuleFor(x => x.Answers)
            .NotEmpty().WithMessage("At least one answer is required.")
            .Must(answers => answers.Any()).WithMessage("The answers list cannot be empty.");

    }

    private bool BeValidGuid(Guid id)
    {
        return id != Guid.Empty;
    }
}
