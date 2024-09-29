using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Search.Dtos;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Search.GlobalSearch;

public class GlobalSearchQuery : IRequest<ApiResponse<GlobalSearchResultDto>>
{
    public string SearchTerm { get; set; }
}
