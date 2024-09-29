using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewById;

public class GetReviewByIdQueryValidator : AbstractValidator<GetReviewByIdQuery>
{
    public GetReviewByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Review ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Invalid Review ID.");
    }
}
