using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.GenerateRandomQuiz;

public class GenerateRandomQuizCommand : IRequest<ApiResponse<QuizDto>>
{
    public Guid CourseId { get; set; }
    public int QuestionCount { get; set; }
}
