using ELearningApi.Data.Enums;

namespace ELearningApi.Core.MediatrHandlers.Quiz;

public class QuizQuestionDto
{
    public Guid Id { get; set; }
    public string QuestionText { get; set; }
    public QuestionType Type { get; set; }
    public int Points { get; set; }
    public int DifficultyLevel { get; set; }
    public string Explanation { get; set; }
    public int OrderIndex { get; set; }
    public List<QuizAnswerDto> Answers { get; set; }
    public List<QuizQuestionMediaDto> Media { get; set; }

}