using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Commands.DeleteCourse;

public class DeleteCourseCommand : IRequest<ApiResponse<string>>
{
    public Guid Id { get; set; }
}
