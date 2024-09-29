using ELearningApi.Data.Enums;

namespace ELearningApi.Core.MediatrHandlers.Quiz;

public class QuizQuestionMediaDto
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public MediaType Type { get; set; }

}