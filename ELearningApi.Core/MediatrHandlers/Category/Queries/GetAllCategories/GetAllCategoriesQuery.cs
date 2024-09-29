using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<ApiResponse<IEnumerable<CategoryDto>>>
{
}
