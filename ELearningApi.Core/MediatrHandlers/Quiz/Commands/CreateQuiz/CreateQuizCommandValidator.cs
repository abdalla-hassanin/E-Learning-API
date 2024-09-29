using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.CreateQuiz;

public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
{
    public CreateQuizCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).MaximumLength(1000);
        RuleFor(x => x.Type).IsInEnum();
        RuleFor(x => x.TimeLimit).GreaterThan(0).When(x => x.TimeLimit.HasValue);
        RuleFor(x => x.PassingScore).InclusiveBetween(0, 100);
        RuleFor(x => x.MaxAttempts).GreaterThan(0);
        RuleFor(x => x.AvailableFrom).NotEmpty();
        RuleFor(x => x.AvailableTo).GreaterThan(x => x.AvailableFrom).When(x => x.AvailableTo.HasValue);
    }
}

