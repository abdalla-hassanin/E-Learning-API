using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<ApiResponse<CategoryDto>>
{
    public string Name { get; set; }
}
