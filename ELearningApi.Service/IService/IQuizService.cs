using ELearningApi.Data.Entities;

namespace ELearningApi.Service.IService;

public interface IQuizService
{
    Task<Quiz> CreateQuizAsync(Quiz quiz, CancellationToken cancellationToken = default);
    Task<Quiz?> GetQuizByIdAsync(Guid quizId, CancellationToken cancellationToken = default);
    Task<Quiz> UpdateQuizAsync(Quiz quiz, CancellationToken cancellationToken = default);
    Task DeleteQuizAsync(Guid quizId, CancellationToken cancellationToken = default);
    Task<QuizQuestion> AddQuestionToQuizAsync(Guid quizId, QuizQuestion question, CancellationToken cancellationToken = default);
    Task<QuizQuestion> UpdateQuestionAsync(QuizQuestion question, CancellationToken cancellationToken = default);
    Task RemoveQuestionFromQuizAsync(Guid quizId, Guid questionId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Quiz>> GetQuizzesByCourseAsync(Guid courseId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Quiz>> GetQuizzesBySectionAsync(Guid sectionId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Quiz>> GetQuizzesByLectureAsync(Guid lectureId, CancellationToken cancellationToken = default);
    Task<Quiz> GenerateRandomQuizAsync(Guid courseId, int numberOfQuestions, CancellationToken cancellationToken = default);
}
