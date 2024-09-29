using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Search.Dtos;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Search.SearchInstructors;

public class SearchInstructorsQuery : IRequest<ApiResponse<IEnumerable<InstructorDto>>>
{
    public string SearchTerm { get; set; }
    public string? Expertise { get; set; }
}
