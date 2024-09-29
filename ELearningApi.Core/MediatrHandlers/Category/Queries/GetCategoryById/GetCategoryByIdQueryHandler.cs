using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ApiResponse<CategoryDto>>
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetCategoryByIdQueryHandler(ICategoryService categoryService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _categoryService = categoryService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetCategoryByIdAsync(request.Id, cancellationToken);
        var categoryDto = _mapper.Map<CategoryDto>(category);
        return _responseHandler.Success(categoryDto);
    }
}
