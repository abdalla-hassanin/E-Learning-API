using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Course.Commands.UpdateCourse;

public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Course ID is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Course title is required.")
                .MaximumLength(200).WithMessage("Course title must not exceed 200 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Course description is required.")
                .MaximumLength(2000).WithMessage("Course description must not exceed 2000 characters.");

            RuleFor(x => x.ShortDescription)
                .NotEmpty().WithMessage("Short description is required.")
                .MaximumLength(500).WithMessage("Short description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category ID is required.");

            RuleFor(x => x.ThumbnailUrl)
                .NotEmpty().WithMessage("Thumbnail URL is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Thumbnail URL must be a valid URL.");

            RuleFor(x => x.TrailerVideoUrl)
                .NotEmpty().WithMessage("Trailer video URL is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Trailer video URL must be a valid URL.");

            RuleFor(x => x.Level)
                .IsInEnum().WithMessage("Invalid course level.");

            RuleFor(x => x.Prerequisites)
                .NotNull().WithMessage("Prerequisites list is required.");

            RuleFor(x => x.LearningObjectives)
                .NotNull().WithMessage("Learning objectives list is required.")
                .Must(list => list.Count > 0).WithMessage("At least one learning objective is required.");

            RuleFor(x => x.EstimatedDuration)
                .NotEmpty().WithMessage("Estimated duration is required.")
                .Must(duration => duration > TimeSpan.Zero)
                .WithMessage("Estimated duration must be greater than zero.");
        }
    }