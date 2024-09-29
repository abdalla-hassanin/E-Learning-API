using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Review.Commands.CreateReview;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment is required.")
            .MaximumLength(1000).WithMessage("Comment must not exceed 1000 characters.");

        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Invalid Student ID.");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Invalid Course ID.");
    }
}

