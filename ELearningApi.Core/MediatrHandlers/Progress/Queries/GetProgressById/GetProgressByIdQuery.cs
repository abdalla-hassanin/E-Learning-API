using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressById;

public class GetProgressByIdQuery : IRequest<ApiResponse<ProgressDto>>
{
    public Guid Id { get; set; }
}
