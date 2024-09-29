using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Instructor.Queries.GetAllInstructors;

public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstructorsQuery, ApiResponse<IEnumerable<InstructorDto>>>
{
    private readonly IInstructorService _instructorService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetAllInstructorsQueryHandler(IInstructorService instructorService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _instructorService = instructorService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<InstructorDto>>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
    {
        var instructors = await _instructorService.GetAllInstructorsAsync(cancellationToken);
        var instructorDtos = _mapper.Map<IEnumerable<InstructorDto>>(instructors);
        return _responseHandler.Success(instructorDtos);
    }
}
