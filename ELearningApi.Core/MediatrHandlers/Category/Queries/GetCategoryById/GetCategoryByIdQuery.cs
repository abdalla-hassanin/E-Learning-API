using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<ApiResponse<CategoryDto>>
{
    public Guid Id { get; set; }
}

