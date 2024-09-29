using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Student.Queries.GetStudentById;

public class GetStudentByIdQuery : IRequest<ApiResponse<StudentDto>>
{
    public Guid Id { get; set; }
}
