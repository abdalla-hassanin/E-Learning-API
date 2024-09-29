using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByCategory;
public class GetCoursesByCategoryQueryValidator : AbstractValidator<GetCoursesByCategoryQuery>
{
    public GetCoursesByCategoryQueryValidator()
    {
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID is required");
    }
}
