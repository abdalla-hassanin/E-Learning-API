using ELearningApi.Data.Entities;

namespace ELearningApi.Service.IService;

public interface IQuizAttemptService
{
    Task<QuizAttempt> StartQuizAttemptAsync(Guid studentId, Guid quizId, CancellationToken cancellationToken = default);
    Task<QuizAttempt> SubmitQuizAttemptAsync(Guid attemptId, IEnumerable<AttemptAnswer> answers, CancellationToken cancellationToken = default);
    Task<QuizAttempt?> GetQuizAttemptResultAsync(Guid attemptId, CancellationToken cancellationToken = default);
    Task<IEnumerable<QuizAttempt>> GetQuizAttemptsForStudentAsync(Guid studentId, Guid quizId, CancellationToken cancellationToken = default);
    Task<IEnumerable<QuizAttempt>> GetQuizAttemptsForQuizAsync(Guid quizId, CancellationToken cancellationToken = default);
    Task<QuizAttempt> CalculateQuizScoreAsync(Guid attemptId, CancellationToken cancellationToken = default);
    Task<IEnumerable<QuizAttempt>> GetQuizAttemptHistoryAsync(Guid studentId, CancellationToken cancellationToken = default);
}
