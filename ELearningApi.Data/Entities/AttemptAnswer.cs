namespace ELearningApi.Data.Entities;

public class AttemptAnswer
{
    public Guid Id { get; set; }
    public Guid QuizAttemptId { get; set; }
    public QuizAttempt QuizAttempt { get; set; }
    public Guid QuestionId { get; set; }
    public string Response { get; set; }
    public bool IsCorrect { get; set; }
    public int PointsEarned { get; set; }
    public TimeSpan TimeTaken { get; set; }
}
