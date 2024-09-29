using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Commands.DeleteCategory;
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ApiResponse<string>>
{
    private readonly ICategoryService _categoryService;
    private readonly ApiResponseHandler _responseHandler;

    public DeleteCategoryCommandHandler(ICategoryService categoryService, ApiResponseHandler responseHandler)
    {
        _categoryService = categoryService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryService.DeleteCategoryAsync(request.Id, cancellationToken);
        return _responseHandler.Deleted<string>("Category deleted successfully.");
    }
}
