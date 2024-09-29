using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionById;

public class GetSectionByIdQueryValidator : AbstractValidator<GetSectionByIdQuery>
{
    public GetSectionByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Section ID is required.");
    }
}
