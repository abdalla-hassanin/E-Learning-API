using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptsForStudent;

public class GetQuizAttemptsForStudentQueryValidator : AbstractValidator<GetQuizAttemptsForStudentQuery>
{
    public GetQuizAttemptsForStudentQueryValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.");
        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("Quiz ID is required.");
    }
}

