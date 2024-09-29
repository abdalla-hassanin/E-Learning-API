using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Student.Queries.GetStudentById;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, ApiResponse<StudentDto>>
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetStudentByIdQueryHandler(IStudentService studentService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _studentService = studentService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdAsync(request.Id, cancellationToken);
        if (student == null)
            return _responseHandler.NotFound<StudentDto>($"Student with ID {request.Id} not found.");

        var studentDto = _mapper.Map<StudentDto>(student);
        return _responseHandler.Success(studentDto);
    }
}
