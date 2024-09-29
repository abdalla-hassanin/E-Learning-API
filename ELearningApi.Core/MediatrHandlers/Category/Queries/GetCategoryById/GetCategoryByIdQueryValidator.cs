using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Category.Queries.GetCategoryById;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Category ID is required");
    }
}