using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptHistory;

public class GetQuizAttemptHistoryQuery : IRequest<ApiResponse<IEnumerable<QuizAttemptDto>>>
{
    public Guid StudentId { get; set; }
}
