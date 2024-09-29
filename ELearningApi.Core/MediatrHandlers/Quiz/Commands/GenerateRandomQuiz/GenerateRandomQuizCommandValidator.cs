using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.GenerateRandomQuiz;

public class GenerateRandomQuizCommandValidator : AbstractValidator<GenerateRandomQuizCommand>
{
    public GenerateRandomQuizCommandValidator()
    {
        RuleFor(x => x.CourseId).NotEmpty();
        RuleFor(x => x.QuestionCount).GreaterThan(0);
    }
}
