using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Commands.DeleteCategory;
public class DeleteCategoryCommand : IRequest<ApiResponse<string>>
{
    public Guid Id { get; set; }
}
