using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResponse<CategoryDto>>
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _categoryService = categoryService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Data.Entities.Category>(request);
        var createdCategory = await _categoryService.CreateCategoryAsync(category, cancellationToken);
        var categoryDto = _mapper.Map<CategoryDto>(createdCategory);
        return _responseHandler.Created(categoryDto);
    }
}

