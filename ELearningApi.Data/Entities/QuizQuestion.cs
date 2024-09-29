using ELearningApi.Data.Enums;

namespace ELearningApi.Data.Entities;

public class QuizQuestion
{
    public Guid Id { get; set; }
public string QuestionText { get; set; }
public QuestionType Type { get; set; }
public int Points { get; set; }
public int DifficultyLevel { get; set; }
public string Explanation { get; set; }
public int OrderIndex { get; set; }
public Guid QuizId { get; set; }
public Quiz Quiz { get; set; }
public List<QuizAnswer> Answers { get; set; } = new List<QuizAnswer>();
public List<QuizQuestionMedia> Media { get; set; } = new List<QuizQuestionMedia>();


}
