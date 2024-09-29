namespace ELearningApi.Core.MediatrHandlers.QuizAttempt;

public class QuizAttemptDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid QuizId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int Score { get; set; }
    public bool IsPassed { get; set; }
    public List<AttemptAnswerDto> Answers { get; set; }
}

