using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ApiResponse<CategoryDto>>
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _categoryService = categoryService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Data.Entities.Category>(request);
        var updatedCategory = await _categoryService.UpdateCategoryAsync(category, cancellationToken);
        var categoryDto = _mapper.Map<CategoryDto>(updatedCategory);
        return _responseHandler.Success(categoryDto, "Category updated successfully.");
    }
}
