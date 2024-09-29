using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.CalculateQuizScore;

public class CalculateQuizScoreCommandValidator : AbstractValidator<CalculateQuizScoreCommand>
{
    public CalculateQuizScoreCommandValidator()
    {
        RuleFor(x => x.AttemptId)
            .NotEmpty().WithMessage("Attempt ID is required.")
            .Must(BeValidGuid).WithMessage("Invalid Attempt ID format.");
    }

    private bool BeValidGuid(Guid id)
    {
        return id != Guid.Empty;
    }
    
}