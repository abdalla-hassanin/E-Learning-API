using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Student.Commands.UpdateStudent;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, ApiResponse<StudentDto>>
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateStudentCommandHandler(IStudentService studentService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _studentService = studentService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<StudentDto>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Data.Entities.Student>(request);
        var updatedStudent = await _studentService.UpdateStudentAsync(student, cancellationToken);
        var studentDto = _mapper.Map<StudentDto>(updatedStudent);
        return _responseHandler.Success(studentDto, "Student updated successfully.");
    }
}
