using ELearningApi.Data.Enums;

namespace ELearningApi.Core.MediatrHandlers.Quiz;

public class QuizDto
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
    public Guid? CourseId { get; set; }
    public Guid? SectionId { get; set; }
    public Guid? LectureId { get; set; }
    public List<QuizQuestionDto> Questions { get; set; }

}