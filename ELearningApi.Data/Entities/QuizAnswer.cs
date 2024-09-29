namespace ELearningApi.Data.Entities;

public class QuizAnswer
{
    public Guid Id { get; set; }
    public string AnswerText { get; set; }
    public bool IsCorrect { get; set; }
    public string Explanation { get; set; }
    public int? OrderIndex { get; set; } // For ordering questions
    public Guid QuestionId { get; set; }
    public QuizQuestion Question { get; set; }
}
