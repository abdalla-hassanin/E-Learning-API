using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizById;

public class GetQuizByIdQuery : IRequest<ApiResponse<QuizDto>>
{
    public Guid QuizId { get; set; }
}

