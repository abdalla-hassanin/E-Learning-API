using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Search.Dtos;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Search.SearchInstructors;

public class SearchInstructorsQueryHandler : IRequestHandler<SearchInstructorsQuery, ApiResponse<IEnumerable<InstructorDto>>>
{
    private readonly ISearchService _searchService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public SearchInstructorsQueryHandler(ISearchService searchService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _searchService = searchService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<InstructorDto>>> Handle(SearchInstructorsQuery request, CancellationToken cancellationToken)
    {
        var instructors = await _searchService.SearchInstructorsAsync(request.SearchTerm, request.Expertise, cancellationToken);
        var instructorDtos = _mapper.Map<IEnumerable<InstructorDto>>(instructors);
        return _responseHandler.Success(instructorDtos, "Instructors retrieved successfully.");
    }
}

