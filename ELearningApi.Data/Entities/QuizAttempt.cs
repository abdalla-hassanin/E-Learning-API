namespace ELearningApi.Data.Entities;


public class QuizAttempt
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int Score { get; set; }
    public bool IsPassed { get; set; }
    public List<AttemptAnswer> Answers { get; set; } = new List<AttemptAnswer>();
}