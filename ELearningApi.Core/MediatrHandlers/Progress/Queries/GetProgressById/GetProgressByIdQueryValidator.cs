using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressById;

public class GetProgressByIdQueryValidator : AbstractValidator<GetProgressByIdQuery>
{
    public GetProgressByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Progress ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid Progress ID.");
    }
}
