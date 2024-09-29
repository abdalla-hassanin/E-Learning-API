using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Instructor.Queries.GetAllInstructors;

public class GetAllInstructorsQuery : IRequest<ApiResponse<IEnumerable<InstructorDto>>>
{
}

