using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptHistory;

public class GetQuizAttemptHistoryQueryValidator : AbstractValidator<GetQuizAttemptHistoryQuery>
{
    public GetQuizAttemptHistoryQueryValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.");
    }
}
