using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Instructor.Commands.UpdateInstructor;

public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, ApiResponse<InstructorDto>>
{
    private readonly IInstructorService _instructorService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateInstructorCommandHandler(IInstructorService instructorService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _instructorService = instructorService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<InstructorDto>> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
    {
        var instructor = _mapper.Map<Data.Entities.Instructor>(request);
        var updatedInstructor = await _instructorService.UpdateInstructorAsync(instructor, cancellationToken);
        var instructorDto = _mapper.Map<InstructorDto>(updatedInstructor);
        return _responseHandler.Success(instructorDto, "Instructor updated successfully.");
    }
}
