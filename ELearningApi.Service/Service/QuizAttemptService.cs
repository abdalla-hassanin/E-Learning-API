using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;
public class QuizAttemptService : IQuizAttemptService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuizService _quizService;

    public QuizAttemptService(IUnitOfWork unitOfWork, IQuizService quizService)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _quizService = quizService ?? throw new ArgumentNullException(nameof(quizService));
    }

    public async Task<QuizAttempt> StartQuizAttemptAsync(Guid studentId, Guid quizId, CancellationToken cancellationToken = default)
    {
        var quiz = await _quizService.GetQuizByIdAsync(quizId, cancellationToken);
        if (quiz == null)
        {
            throw new ArgumentException("Quiz not found", nameof(quizId));
        }

        var attempt = new QuizAttempt
        {
            StudentId = studentId,
            QuizId = quizId,
            StartTime = DateTime.UtcNow,
            Score = 0,
            IsPassed = false
        };

        await _unitOfWork.Repository<QuizAttempt>().AddAsync(attempt, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return attempt;
    }

    public async Task<QuizAttempt> SubmitQuizAttemptAsync(Guid attemptId, IEnumerable<AttemptAnswer> answers, CancellationToken cancellationToken = default)
    {
        var attempt = await GetQuizAttemptByIdAsync(attemptId, cancellationToken);
        if (attempt == null)
        {
            throw new ArgumentException("Quiz attempt not found", nameof(attemptId));
        }

        attempt.EndTime = DateTime.UtcNow;
        attempt.Answers = answers.ToList();

        await _unitOfWork.Repository<QuizAttempt>().UpdateAsync(attempt, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        // Calculate score and update
        attempt = await CalculateQuizScoreAsync(attemptId, cancellationToken);

        return attempt;
    }

    public async Task<QuizAttempt?> GetQuizAttemptResultAsync(Guid attemptId, CancellationToken cancellationToken = default)
    {
        var spec = new Specification<QuizAttempt>(a => a.Id == attemptId)
            .AddInclude(a => a.Include(x => x.Answers))
            .AddInclude(a => a.Include(x => x.Quiz).ThenInclude(q => q.Questions));

        var attempt = await _unitOfWork.Repository<QuizAttempt>().FindBySpecificationAsync(spec, cancellationToken);
        return attempt.FirstOrDefault();
    }

    public async Task<IEnumerable<QuizAttempt>> GetQuizAttemptsForStudentAsync(Guid studentId, Guid quizId, CancellationToken cancellationToken = default)
    {
        var spec = new Specification<QuizAttempt>(a => a.StudentId == studentId && a.QuizId == quizId)
            .AddInclude(a => a.Include(x => x.Quiz));

        return await _unitOfWork.Repository<QuizAttempt>().FindBySpecificationAsync(spec, cancellationToken);
    }

    public async Task<IEnumerable<QuizAttempt>> GetQuizAttemptsForQuizAsync(Guid quizId, CancellationToken cancellationToken = default)
    {
        var spec = new Specification<QuizAttempt>(a => a.QuizId == quizId)
            .AddInclude(a => a.Include(x => x.Student));

        return await _unitOfWork.Repository<QuizAttempt>().FindBySpecificationAsync(spec, cancellationToken);
    }

    public async Task<QuizAttempt> CalculateQuizScoreAsync(Guid attemptId, CancellationToken cancellationToken = default)
    {
        var attempt = await GetQuizAttemptResultAsync(attemptId, cancellationToken);
        if (attempt == null)
        {
            throw new ArgumentException("Quiz attempt not found", nameof(attemptId));
        }

        int totalPoints = attempt.Quiz.Questions.Sum(q => q.Points);
        int earnedPoints = 0;

        foreach (var answer in attempt.Answers)
        {
            var question = attempt.Quiz.Questions.FirstOrDefault(q => q.Id == answer.QuestionId);
            if (question != null)
            {
                if (IsAnswerCorrect(question, answer))
                {
                    earnedPoints += question.Points;
                    answer.IsCorrect = true;
                }
                answer.PointsEarned = answer.IsCorrect ? question.Points : 0;
            }
        }

        attempt.Score = (int)Math.Round((double)earnedPoints / totalPoints * 100);
        attempt.IsPassed = attempt.Score >= attempt.Quiz.PassingScore;

        await _unitOfWork.Repository<QuizAttempt>().UpdateAsync(attempt, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return attempt;
    }

    public async Task<IEnumerable<QuizAttempt>> GetQuizAttemptHistoryAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        var spec = new Specification<QuizAttempt>(a => a.StudentId == studentId)
            .AddInclude(a => a.Include(x => x.Quiz))
            .ApplyOrderBy(q => q.OrderByDescending(a => a.StartTime));

        return await _unitOfWork.Repository<QuizAttempt>().FindBySpecificationAsync(spec, cancellationToken);
    }

    private async Task<QuizAttempt?> GetQuizAttemptByIdAsync(Guid attemptId, CancellationToken cancellationToken = default)
    {
        var spec = new Specification<QuizAttempt>(a => a.Id == attemptId);
        var attempt = await _unitOfWork.Repository<QuizAttempt>().FindBySpecificationAsync(spec, cancellationToken);
        return attempt.FirstOrDefault();
    }

    private bool IsAnswerCorrect(QuizQuestion question, AttemptAnswer answer)
    {
        switch (question.Type)
        {
            case QuestionType.MultipleChoice:
            case QuestionType.TrueFalse:
                return question.Answers.Any(a => a.IsCorrect && a.Id.ToString() == answer.Response);
            case QuestionType.MultipleAnswer:
                var correctAnswerIds = question.Answers.Where(a => a.IsCorrect).Select(a => a.Id.ToString());
                var givenAnswerIds = answer.Response.Split(',');
                return correctAnswerIds.OrderBy(id => id).SequenceEqual(givenAnswerIds.OrderBy(id => id));
            default:
                throw new NotImplementedException($"Question type {question.Type} is not supported.");
        }
    }
}
