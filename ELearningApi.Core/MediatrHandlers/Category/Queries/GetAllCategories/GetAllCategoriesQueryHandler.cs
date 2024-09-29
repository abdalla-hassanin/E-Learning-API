using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Category.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ApiResponse<IEnumerable<CategoryDto>>>
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetAllCategoriesQueryHandler(ICategoryService categoryService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _categoryService = categoryService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetAllCategoriesAsync(cancellationToken);
        var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return _responseHandler.Success(categoryDtos);
    }
}