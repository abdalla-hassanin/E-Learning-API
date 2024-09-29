using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Student.Queries.GetAllStudents;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, ApiResponse<IEnumerable<StudentDto>>>
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetAllStudentsQueryHandler(IStudentService studentService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _studentService = studentService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<StudentDto>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentService.GetAllStudentsAsync(cancellationToken);
        var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
        return _responseHandler.Success(studentDtos);
    }
}
