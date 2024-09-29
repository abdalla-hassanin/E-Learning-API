using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Review.Commands.DeleteReview;

public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
{
    public DeleteReviewCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Review ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Invalid Review ID.");
    }
}
