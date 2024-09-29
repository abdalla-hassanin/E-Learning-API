using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewById;

public class GetReviewByIdQuery : IRequest<ApiResponse<ReviewDto>>
{
    public Guid Id { get; set; }
}
