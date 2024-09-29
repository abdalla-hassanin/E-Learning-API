namespace ELearningApi.Core.MediatrHandlers.QuizAttempt;

public class AttemptAnswerDto
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Response { get; set; }
    public bool IsCorrect { get; set; }
    public int PointsEarned { get; set; }
    public TimeSpan TimeTaken { get; set; }

}
