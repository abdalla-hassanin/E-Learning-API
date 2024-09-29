using ELearningApi.Data.Enums;

namespace ELearningApi.Data.Entities;

public class Quiz
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public QuizType Type { get; set; }
    public int? TimeLimit { get; set; } // in minutes, null for unlimited
    public int PassingScore { get; set; }
    public bool IsRandomized { get; set; }
    public bool ShowCorrectAnswers { get; set; }
    public int MaxAttempts { get; set; }
    public DateTime AvailableFrom { get; set; }
    public DateTime? AvailableTo { get; set; }
    public Guid? CourseId { get; set; }
    public Course Course { get; set; }
    public Guid? SectionId { get; set; }
    public Section Section { get; set; }
    public Guid? LectureId { get; set; }
    public Lecture Lecture { get; set; }
    public List<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
    public List<QuizAttempt> Attempts { get; set; } = new List<QuizAttempt>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
