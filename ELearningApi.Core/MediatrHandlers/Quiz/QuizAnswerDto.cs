namespace ELearningApi.Core.MediatrHandlers.Quiz;

public class QuizAnswerDto
{
    public Guid Id { get; set; }
    public string AnswerText { get; set; }
    public bool IsCorrect { get; set; }
    public string Explanation { get; set; }
    public int? OrderIndex { get; set; }

}