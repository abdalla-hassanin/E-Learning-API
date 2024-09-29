using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<ApiResponse<CategoryDto>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
