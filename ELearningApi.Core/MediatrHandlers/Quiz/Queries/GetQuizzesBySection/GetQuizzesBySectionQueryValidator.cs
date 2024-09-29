using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesBySection;

public class GetQuizzesBySectionQueryValidator: AbstractValidator<GetQuizzesBySectionQuery>
{
    public GetQuizzesBySectionQueryValidator()
    {
        RuleFor(x => x.SectionId)
            .NotEmpty().WithMessage("Section ID is required.");

    }

}