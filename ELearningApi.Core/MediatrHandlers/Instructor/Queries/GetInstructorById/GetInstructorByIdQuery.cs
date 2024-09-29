using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Instructor.Queries.GetInstructorById;

public class GetInstructorByIdQuery : IRequest<ApiResponse<InstructorDto>>
{
    public Guid Id { get; set; }
}
