using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Instructor.Queries.GetInstructorById;

public class GetInstructorByIdQueryHandler : IRequestHandler<GetInstructorByIdQuery, ApiResponse<InstructorDto>>
{
    private readonly IInstructorService _instructorService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetInstructorByIdQueryHandler(IInstructorService instructorService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _instructorService = instructorService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<InstructorDto>> Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
    {
        var instructor = await _instructorService.GetInstructorByIdAsync(request.Id, cancellationToken);
        if (instructor == null)
            return _responseHandler.NotFound<InstructorDto>($"Instructor with ID {request.Id} not found.");

        var instructorDto = _mapper.Map<InstructorDto>(instructor);
        return _responseHandler.Success(instructorDto);
    }
}
