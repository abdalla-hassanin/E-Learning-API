using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

public class QuizService : IQuizService
{
    private readonly IUnitOfWork _unitOfWork;

    public QuizService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Quiz> CreateQuizAsync(Quiz quiz, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.Repository<Quiz>().AddAsync(quiz, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return quiz;
    }

    public async Task<Quiz?> GetQuizByIdAsync(Guid quizId, CancellationToken cancellationToken = default)
    {
        var quizSpec = new Specification<Quiz>(q => q.Id == quizId)
            .AddInclude(q => q.Include(x => x.Questions).ThenInclude(qs => qs.Answers))
            .AddInclude(q => q.Include(x => x.Questions).ThenInclude(qs => qs.Media));

        var quiz = await _unitOfWork.Repository<Quiz>().FindBySpecificationAsync(quizSpec, cancellationToken);
        return quiz.FirstOrDefault();
    }

    public async Task<Quiz> UpdateQuizAsync(Quiz quiz, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.Repository<Quiz>().UpdateAsync(quiz, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return quiz;
    }

    public async Task DeleteQuizAsync(Guid quizId, CancellationToken cancellationToken = default)
    {
        var quiz = await GetQuizByIdAsync(quizId, cancellationToken);
        if (quiz != null)
        {
            await _unitOfWork.Repository<Quiz>().RemoveAsync(quiz, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }
    }

    public async Task<QuizQuestion> AddQuestionToQuizAsync(Guid quizId, QuizQuestion question, CancellationToken cancellationToken = default)
    {
        var quiz = await GetQuizByIdAsync(quizId, cancellationToken);
        if (quiz == null)
        {
            throw new ArgumentException("Quiz not found", nameof(quizId));
        }

        quiz.Questions.Add(question);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return question;
    }


    public async Task<QuizQuestion> UpdateQuestionAsync(QuizQuestion question, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.Repository<QuizQuestion>().UpdateAsync(question, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return question;
    }

    public async Task RemoveQuestionFromQuizAsync(Guid quizId, Guid questionId, CancellationToken cancellationToken = default)
    {
        var quiz = await GetQuizByIdAsync(quizId, cancellationToken);
        if (quiz == null)
        {
            throw new ArgumentException("Quiz not found", nameof(quizId));
        }

        var question = quiz.Questions.FirstOrDefault(q => q.Id == questionId);
        if (question != null)
        {
            quiz.Questions.Remove(question);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }
    }

    public async Task<IEnumerable<Quiz>> GetQuizzesByCourseAsync(Guid courseId, CancellationToken cancellationToken = default)
    {
        var spec = new Specification<Quiz>(q => q.CourseId == courseId);
        return await _unitOfWork.Repository<Quiz>().FindBySpecificationAsync(spec, cancellationToken);
    }

    public async Task<IEnumerable<Quiz>> GetQuizzesBySectionAsync(Guid sectionId, CancellationToken cancellationToken = default)
    {
        var spec = new Specification<Quiz>(q => q.SectionId == sectionId);
        return await _unitOfWork.Repository<Quiz>().FindBySpecificationAsync(spec, cancellationToken);
    }

    public async Task<IEnumerable<Quiz>> GetQuizzesByLectureAsync(Guid lectureId, CancellationToken cancellationToken = default)
    {
        var spec = new Specification<Quiz>(q => q.LectureId == lectureId);
        return await _unitOfWork.Repository<Quiz>().FindBySpecificationAsync(spec, cancellationToken);
    }

    public async Task<Quiz> GenerateRandomQuizAsync(Guid courseId, int questionCount, CancellationToken cancellationToken = default)
    {
        var courseQuizzes = await GetQuizzesByCourseAsync(courseId, cancellationToken);
        var allQuestions = courseQuizzes.SelectMany(q => q.Questions).ToList();

        if (allQuestions.Count < questionCount)
        {
            throw new InvalidOperationException("Not enough questions available to generate a random quiz.");
        }

        var randomQuestions = allQuestions.OrderBy(q => Guid.NewGuid()).Take(questionCount).ToList();

        var randomQuiz = new Quiz
        {
            Title = "Random Quiz",
            Description = "Randomly generated quiz",
            CourseId = courseId,
            Type = QuizType.Standalone,
            Questions = randomQuestions
        };

        return await CreateQuizAsync(randomQuiz, cancellationToken);
    }
}
