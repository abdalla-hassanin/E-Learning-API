using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Enums;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuiz;

public class UpdateQuizCommand : IRequest<ApiResponse<QuizDto>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public QuizType Type { get; set; }
    public int? TimeLimit { get; set; }
    public int PassingScore { get; set; }
    public bool IsRandomized { get; set; }
    public bool ShowCorrectAnswers { get; set; }
    public int MaxAttempts { get; set; }
    public DateTime AvailableFrom { get; set; }
    public DateTime? AvailableTo { get; set; }
}
