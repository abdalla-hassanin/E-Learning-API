using ELearningApi.Data.Enums;

namespace ELearningApi.Data.Entities;

public class QuizQuestionMedia
 {
 public Guid Id { get; set; }
 public string Url { get; set; }
 public MediaType Type { get; set; }
 public Guid QuestionId { get; set; }
 public QuizQuestion Question { get; set; }
 }
