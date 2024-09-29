using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Student.Queries.GetAllStudents;

public class GetAllStudentsQuery : IRequest<ApiResponse<IEnumerable<StudentDto>>>
{
}

