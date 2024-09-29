// public class ApplicationUser : IdentityUser
// {
//     public string FirstName { get; set; }
//     public string LastName { get; set; }
//     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
//     public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
//     
//     public string RefreshToken { get; set; }
//     public DateTime RefreshTokenExpiryTime { get; set; }
//
// }
// public class Student 
// {
//     public Guid Id { get; set; }
//     public string UserId { get; set; }
//     public ApplicationUser ApplicationUser { get; set; }
//     public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
// }
//
// public class Instructor
// {
//     public Guid Id { get; set; }
//     public string UserId { get; set; }
//     public ApplicationUser ApplicationUser { get; set; }
//     public string Expertise { get; set; }
//     public string Biography { get; set; }
//     public List<Course> Courses { get; set; } = new List<Course>();
// }
// public class Course
// {
//     public Guid Id { get; set; }
//     public string Title { get; set; }
//     public string Description { get; set; }
//     public string ShortDescription { get; set; }
//     public decimal Price { get; set; }
//     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
//     public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
//     public Guid InstructorId { get; set; }
//     public Instructor Instructor { get; set; }
//     public Guid CategoryId { get; set; }
//     public Category Category { get; set; }
//     public List<Section> Sections { get; set; } = new List<Section>();
//     public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
//     public List<Review> Reviews { get; set; } = new List<Review>();
//     public string ThumbnailUrl { get; set; }
//     public string TrailerVideoUrl { get; set; }
//     public CourseLevel Level { get; set; }
//     public List<string> Prerequisites { get; set; } = new List<string>();
//     public List<string> LearningObjectives { get; set; } = new List<string>();
//     public TimeSpan EstimatedDuration { get; set; }
//     public DateTime? PublishedAt { get; set; }
// }
// public class Enrollment
// {
//     public Guid Id { get; set; }
//     public Guid StudentId { get; set; }
//     public Student Student { get; set; }
//     public Guid CourseId { get; set; }
//     public Course Course { get; set; }
//     public DateTime EnrolledAt { get; set; }
//     public DateTime? CompletedAt { get; set; }
//     public EnrollmentStatus Status { get; set; }
//     public decimal Progress { get; set; }
//     public List<Progress> Progresses { get; set; } = new List<Progress>();
// }
// public class Category
// {
//     public Guid Id { get; set; }
//     public string Name { get; set; }
//     public List<Course> Courses { get; set; } = new List<Course>();
// }
// public class Section
// {
//     public Guid Id { get; set; }
//     public string Title { get; set; }
//     public string Description { get; set; }
//     public int OrderIndex { get; set; }
//     public Guid CourseId { get; set; }
//     public Course Course { get; set; }
//     public List<Lecture> Lectures { get; set; } = new List<Lecture>();
//     public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
// }
// public class Lecture
// {
//     public Guid Id { get; set; }
//     public string Title { get; set; }
//     public string Description { get; set; }
//     public string Content { get; set; }
//     public TimeSpan Duration { get; set; }
//     public int OrderIndex { get; set; }
//     public Guid SectionId { get; set; }
//     public Section Section { get; set; }
//     public List<Progress> Progresses { get; set; } = new List<Progress>();
//     public List<LectureResource> Resources { get; set; } = new List<LectureResource>();
//     public LectureType Type { get; set; }
//     public string VideoUrl { get; set; }
// }
// public class LectureResource
// {
//     public Guid Id { get; set; }
//     public string Title { get; set; }
//     public string Description { get; set; }
//     public string Url { get; set; }
//     public ResourceType Type { get; set; }
//     public Guid LectureId { get; set; }
//     public Lecture Lecture { get; set; }
// }
// public class Progress
// {
//     public Guid Id { get; set; }
//     public Guid EnrollmentId { get; set; }
//     public Enrollment Enrollment { get; set; }
//     public Guid LectureId { get; set; }
//     public Lecture Lecture { get; set; }
//     public DateTime? StartedAt { get; set; }
//     public DateTime? CompletedAt { get; set; }
//     public ProgressStatus Status { get; set; }
//     public decimal ProgressPercentage { get; set; }
// }
// public class Payment
// {
//     public Guid Id { get; set; }
//     public decimal Amount { get; set; }
//     public PaymentStatus Status { get; set; }
//     public string Method { get; set; }
//     public string PaymentReferenceId { get; set; }
//     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
//     public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
//     public Guid StudentId { get; set; }
//     public Student Student { get; set; }
//     public Guid CourseId { get; set; }
//     public Course Course { get; set; }
//
// }
// public class Review
// {
//     public Guid Id { get; set; }
//     public int Rating { get; set; }
//     public string Comment { get; set; }
//     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
//     public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
//     public Guid StudentId { get; set; }
//     public Student Student { get; set; }
//     public Guid CourseId { get; set; }
//     public Course Course { get; set; }
//     
//     
// }
// public class Quiz
// {
//     public Guid Id { get; set; }
//     public string Title { get; set; }
//     public string Description { get; set; }
//     public QuizType Type { get; set; }
//     public int? TimeLimit { get; set; } // in minutes, null for unlimited
//     public int PassingScore { get; set; }
//     public bool IsRandomized { get; set; }
//     public bool ShowCorrectAnswers { get; set; }
//     public int MaxAttempts { get; set; }
//     public DateTime AvailableFrom { get; set; }
//     public DateTime? AvailableTo { get; set; }
//     public Guid? CourseId { get; set; }
//     public Course Course { get; set; }
//     public Guid? SectionId { get; set; }
//     public Section Section { get; set; }
//     public Guid? LectureId { get; set; }
//     public Lecture Lecture { get; set; }
//     public List<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
//     public List<QuizAttempt> Attempts { get; set; } = new List<QuizAttempt>();
//     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
//     public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
// }
// public class QuizQuestion
// {
//     public Guid Id { get; set; }
//     public string QuestionText { get; set; }
//     public QuestionType Type { get; set; }
//     public int Points { get; set; }
//     public int DifficultyLevel { get; set; }
//     public string Explanation { get; set; }
//     public int OrderIndex { get; set; }
//     public Guid QuizId { get; set; }
//     public Quiz Quiz { get; set; }
//     public List<QuizAnswer> Answers { get; set; } = new List<QuizAnswer>();
//     public List<QuizQuestionMedia> Media { get; set; } = new List<QuizQuestionMedia>();
//
//
// }
// public class QuizAnswer
// {
//     public Guid Id { get; set; }
//     public string AnswerText { get; set; }
//     public bool IsCorrect { get; set; }
//     public string Explanation { get; set; }
//     public int? OrderIndex { get; set; } // For ordering questions
//     public Guid QuestionId { get; set; }
//     public QuizQuestion Question { get; set; }
// }
// public class QuizQuestionMedia
// {
//     public Guid Id { get; set; }
//     public string Url { get; set; }
//     public MediaType Type { get; set; }
//     public Guid QuestionId { get; set; }
//     public QuizQuestion Question { get; set; }
// }
//
//
//
// public class QuizAttempt
// {
//     public Guid Id { get; set; }
//     public Guid StudentId { get; set; }
//     public Student Student { get; set; }
//     public Guid QuizId { get; set; }
//     public Quiz Quiz { get; set; }
//     public DateTime StartTime { get; set; }
//     public DateTime? EndTime { get; set; }
//     public int Score { get; set; }
//     public bool IsPassed { get; set; }
//     public List<AttemptAnswer> Answers { get; set; } = new List<AttemptAnswer>();
// }
//
// public class AttemptAnswer
// {
//     public Guid Id { get; set; }
//     public Guid QuizAttemptId { get; set; }
//     public QuizAttempt QuizAttempt { get; set; }
//     public Guid QuestionId { get; set; }
//     public string Response { get; set; }
//     public bool IsCorrect { get; set; }
//     public int PointsEarned { get; set; }
//     public TimeSpan TimeTaken { get; set; }
// }
// public enum EnrollmentStatus
// {
//     Enrolled,
//     InProgress,
//     Completed
// }
// public enum PaymentStatus
// {
//     Pending,
//     Completed,
//     Failed,
//     Refunded
// }public enum ProgressStatus
// {
//     NotStarted,
//     InProgress,
//     Completed
// }
// public enum QuestionType
// {
//     MultipleChoice, MultipleAnswer, TrueFalse, ShortAnswer, 
//     Essay, Matching, Ordering, FillInTheBlank, Numerical
// }
// public enum QuizType { Course, Section, Lecture, Standalone }
// public enum MediaType { Image, Audio, Video }

// public enum CourseLevel
// {
//     Beginner,
//     Intermediate,
//     Advanced,
//     AllLevels
// }
//
// public enum LectureType
// {
//     Video,
//     Text,
//     Presentation,
//     LiveSession
// }
//
// public enum ResourceType
// {
//     Document,
//     Spreadsheet,
//     Presentation,
//     Video,
//     Audio,
//     Link
// }
//
// public class ApplicationDbContext : IdentityDbContext<Data.Entities.ApplicationUser>
// {
//     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
//     {
//     }
//     public DbSet<Student> Students { get; set; }
//     public DbSet<Instructor> Instructors { get; set; }
//     public DbSet<Course> Courses { get; set; }
//     public DbSet<Category> Categories { get; set; }
//     public DbSet<Section> Sections { get; set; }
//     public DbSet<Lecture> Lectures { get; set; }
//     public DbSet<LectureResource> LectureResources { get; set; }
//     public DbSet<Enrollment> Enrollments { get; set; }
//     public DbSet<Progress> Progresses { get; set; }
//     public DbSet<Payment> Payments { get; set; }
//     public DbSet<Review> Reviews { get; set; }
//     public DbSet<Quiz> Quizzes { get; set; }
//     public DbSet<QuizQuestion> QuizQuestions { get; set; }
//     public DbSet<QuizAnswer> QuizAnswers { get; set; }
//     public DbSet<QuizQuestionMedia> QuizQuestionMedia { get; set; }
//     public DbSet<QuizAttempt> QuizAttempts { get; set; }
//     public DbSet<AttemptAnswer> AttemptAnswers { get; set; }
//
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         base.OnModelCreating(modelBuilder);
//         modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
//         modelBuilder.ApplyConfiguration(new StudentConfiguration());
//         modelBuilder.ApplyConfiguration(new InstructorConfiguration());
//         modelBuilder.ApplyConfiguration(new CourseConfiguration());
//         modelBuilder.ApplyConfiguration(new CategoryConfiguration());
//         modelBuilder.ApplyConfiguration(new SectionConfiguration());
//         modelBuilder.ApplyConfiguration(new LectureConfiguration());
//         modelBuilder.ApplyConfiguration(new LectureResourceConfiguration());
//         modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
//         modelBuilder.ApplyConfiguration(new ProgressConfiguration());
//         modelBuilder.ApplyConfiguration(new PaymentConfiguration());
//         modelBuilder.ApplyConfiguration(new ReviewConfiguration());
//         modelBuilder.ApplyConfiguration(new QuizConfiguration());
//         modelBuilder.ApplyConfiguration(new QuizQuestionConfiguration());
//         modelBuilder.ApplyConfiguration(new QuizAnswerConfiguration());
//         modelBuilder.ApplyConfiguration(new QuizQuestionMediaConfiguration());
//         modelBuilder.ApplyConfiguration(new QuizAttemptConfiguration());
//         modelBuilder.ApplyConfiguration(new AttemptAnswerConfiguration());
//
//         //  Seed Roles
//         modelBuilder.Entity<IdentityRole>().HasData(
//             new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
//             new IdentityRole { Name = "Teacher", NormalizedName = "TEACHER" },
//             new IdentityRole { Name = "Student", NormalizedName = "STUDENT" }
//         );
//     }
// }

//-----------------------------------------------------------------------------------

// using System.Linq.Expressions;
// using ELearningApi.Infrustructure.Context;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Query;
//
// namespace ELearningApi.Infrustructure.Base;
//
// public class GenericRepository<T> : IGenericRepository<T> where T : class
// {
//     private readonly ApplicationDbContext _context;
//     private readonly DbSet<T> _dbSet;
//
//     public GenericRepository(ApplicationDbContext context)
//     {
//         _context = context ?? throw new ArgumentNullException(nameof(context));
//         _dbSet = _context.Set<T>();
//     }
//
//     public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
//     {
//         return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
//     }
//
//     public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
//     {
//         return await _dbSet.ToListAsync(cancellationToken);
//     }
//
//     public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
//     {
//         await _dbSet.AddAsync(entity, cancellationToken);
//     }
//
//     public async Task AddMultipleAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
//     {
//         await _dbSet.AddRangeAsync(entities, cancellationToken);
//     }
//
//     public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
//     {
//         _dbSet.Update(entity);
//         return Task.CompletedTask;
//     }
//
//     public Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
//     {
//         _dbSet.UpdateRange(entities);
//         return Task.CompletedTask;
//     }
//
//     public Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
//     {
//         _dbSet.Remove(entity);
//         return Task.CompletedTask;
//     }
//
//     public Task RemoveMultipleAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
//     {
//         _dbSet.RemoveRange(entities);
//         return Task.CompletedTask;
//     }
//
//
//     public async Task<IEnumerable<T>> FindAsync(
//         Expression<Func<T, bool>> predicate,
//         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
//         CancellationToken cancellationToken = default)
//     {
//         IQueryable<T> query = _dbSet;
//
//         if (include != null)
//         {
//             query = include(query);
//         }
//
//         return await query.Where(predicate).ToListAsync(cancellationToken);
//     }
//     public IQueryable<T> Find(
//         Expression<Func<T, bool>> predicate,
//         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
//     {
//         IQueryable<T> query = _dbSet;
//     
//         if (include != null)
//         {
//             query = include(query);
//         }
//     
//         return query.Where(predicate); 
//     }
//
//
//     public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
//     {
//         return await _dbSet.AnyAsync(predicate, cancellationToken);
//     }
//
//     public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
//     {
//         return await _dbSet.CountAsync(predicate, cancellationToken);
//     }
//
//     public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
//         Expression<Func<T, bool>> predicate,
//         int pageNumber,
//         int pageSize,
//         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
//         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
//         CancellationToken cancellationToken = default)
//     {
//         if (pageNumber <= 0 || pageSize <= 0)
//         {
//             throw new ArgumentException("Page number and page size must be greater than zero.");
//         }
//
//         IQueryable<T> query = _dbSet;
//
//         if (include != null)
//         {
//             query = include(query);
//         }
//
//         query = query.Where(predicate);
//
//         int totalCount = await query.CountAsync(cancellationToken);
//
//         if (orderBy != null)
//         {
//             query = orderBy(query);
//         }
//
//         var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
//
//         return (items, totalCount);
//     }
//     public async Task<IEnumerable<T>> FindBySpecificationAsync(
//         ISpecification<T> specification,
//         CancellationToken cancellationToken = default)
//     {
//         IQueryable<T> query = _dbSet;
//
//         if (specification.Criteria != null)
//         {
//             query = query.Where(specification.Criteria);
//         }
//
//         foreach (var include in specification.Includes)
//         {
//             query = include(query);
//         }
//
//         if (specification.OrderBy != null)
//         {
//             query = specification.OrderBy(query);
//         }
//
//         if (specification.Skip.HasValue)
//         {
//             query = query.Skip(specification.Skip.Value);
//         }
//
//         if (specification.Take.HasValue)
//         {
//             query = query.Take(specification.Take.Value);
//         }
//
//         return await query.ToListAsync(cancellationToken);
//     }
// }
// using System.Linq.Expressions;
//
// namespace ELearningApi.Infrustructure.Base;
//
// public class Specification<T> : ISpecification<T>
// {
//     public Specification(Expression<Func<T, bool>> criteria)
//     {
//         Criteria = criteria;
//         Includes = new List<Func<IQueryable<T>, IQueryable<T>>>();
//     }
//
//     public Expression<Func<T, bool>> Criteria { get; }
//
//     public List<Func<IQueryable<T>, IQueryable<T>>> Includes { get; }
//
//     public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; private set; }
//
//     public int? Skip { get; private set; }
//     public int? Take { get; private set; }
//
//     public Specification<T> AddInclude(Func<IQueryable<T>, IQueryable<T>> includeExpression)
//     {
//         Includes.Add(includeExpression);
//         return this;
//     }
//
//     public Specification<T> ApplyOrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderByExpression)
//     {
//         OrderBy = orderByExpression;
//         return this;
//     }
//
//     public Specification<T> ApplyPaging(int skip, int take)
//     {
//         Skip = skip;
//         Take = take;
//         return this;
//     }
// }
// using ELearningApi.Infrustructure.Context;
// using Microsoft.EntityFrameworkCore.Storage;
//
// namespace ELearningApi.Infrustructure.Base;
//
// public class UnitOfWork : IUnitOfWork, IDisposable
// {
//     private readonly ApplicationDbContext _context;
//     private IDbContextTransaction _transaction;
//     private bool _disposed = false;
//     private readonly Dictionary<Type, object> _repositories = new();
//
//     public UnitOfWork(ApplicationDbContext context)
//     {
//         _context = context ?? throw new ArgumentNullException(nameof(context));
//     }
//
//     public IGenericRepository<T> Repository<T>() where T : class
//     {
//         if (_repositories.ContainsKey(typeof(T)))
//         {
//             return _repositories[typeof(T)] as IGenericRepository<T>;
//         }
//
//         var repository = new GenericRepository<T>(_context);
//         _repositories[typeof(T)] = repository;
//         return repository;
//     }
//
//     public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
//     {
//         if (_transaction != null)
//         {
//             throw new InvalidOperationException("A transaction is already in progress.");
//         }
//
//         _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
//     }
//
//     public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
//     {
//         if (_transaction == null)
//         {
//             throw new InvalidOperationException("No transaction in progress.");
//         }
//
//         try
//         {
//             await _context.SaveChangesAsync(cancellationToken);
//             await _transaction.CommitAsync(cancellationToken);
//         }
//         catch
//         {
//             await RollbackTransactionAsync(cancellationToken); // Ensure this is awaited
//             throw;
//         }
//         finally
//         {
//             await _transaction.DisposeAsync(); // Ensure proper asynchronous disposal
//             _transaction = null;
//         }
//     }
//
//     public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
//     {
//         if (_transaction == null)
//         {
//             throw new InvalidOperationException("No transaction in progress.");
//         }
//
//         try
//         {
//             await _transaction.RollbackAsync(cancellationToken); // Ensure this is awaited
//         }
//         finally
//         {
//             await _transaction.DisposeAsync(); // Ensure proper asynchronous disposal
//             _transaction = null;
//         }
//     }
//
//     public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
//     {
//         return await _context.SaveChangesAsync(cancellationToken);
//     }
//
//     protected virtual void Dispose(bool disposing)
//     {
//         if (!_disposed)
//         {
//             if (disposing)
//             {
//                 foreach (var repository in _repositories.Values)
//                 {
//                     if (repository is IDisposable disposableRepository)
//                     {
//                         disposableRepository.Dispose();
//                     }
//                 }
//
//                 _context.Dispose();
//                 _transaction?.Dispose();
//             }
//
//             _disposed = true;
//         }
//     }
//
//     public void Dispose()
//     {
//         Dispose(true);
//         GC.SuppressFinalize(this);
//     }
// }
// using System.Net;
//
// namespace RoshettaProAPI.Core.Base.ApiResponse;
//
// public class ApiResponse<T> where T : class
//
// {
//
//     // HTTP status code of the response
//
//     public HttpStatusCode StatusCode { get; set; }
//
//     // Additional metadata related to the response
//
//     public Dictionary<string, object>? Meta { get; set; }
//
//     // Indicates whether the request was successful
//
//     public bool Succeeded { get; set; }
//
//     // Message providing additional information about the response
//
//     public string? Message { get; set; }
//
//     // List of errors encountered during the request
//
//     public List<string> Errors { get; set; } = new List<string>();
//
//     // Data payload of the response
//
//     public T? Data { get; set; }
//
//     // Static factory methods to create responses
//
//     // Success response
//
//     public static ApiResponse<T> Success(T data, string? message = null, Dictionary<string, object>? meta = null) => new ApiResponse<T>
//
//     {
//
//         Data = data,
//
//         Succeeded = true,
//
//         StatusCode = HttpStatusCode.OK,
//
//         Message = message,
//
//         Meta = meta
//
//     };
//
//     // Created response
//
//     public static ApiResponse<T> Created(T data, Dictionary<string, object>? meta = null) => new ApiResponse<T>
//
//     {
//
//         Data = data,
//
//         Succeeded = true,
//
//         StatusCode = HttpStatusCode.Created,
//
//         Meta = meta
//
//     };
//
//     // Error response
//
//     public static ApiResponse<T> Error(HttpStatusCode statusCode, string? message, List<string>? errors = null) => new ApiResponse<T>
//
//     {
//
//         Succeeded = false,
//
//         StatusCode = statusCode,
//
//         Message = message,
//
//         Errors = errors ?? new List<string>()
//
//     };
//
//     // Deleted response
//
//     public static ApiResponse<T> Deleted(string? message = null) => new ApiResponse<T>
//
//     {
//
//         Succeeded = true,
//
//         StatusCode = HttpStatusCode.OK,
//
//         Message = message
//
//     };
//
// }
//
// using System.Net;
//
// namespace RoshettaProAPI.Core.Base.ApiResponse;
//
// public class ApiResponseHandler
//
// {
//
//     // Constructor kept protected for inheritance
//
//     public ApiResponseHandler() { }
//
//     // Reusable private method for error responses
//
//     private ApiResponse<T> CreateErrorResponse<T>(HttpStatusCode statusCode, string? message) where T : class
//
//     {
//
//         return ApiResponse<T>.Error(statusCode, message);
//
//     }
//
//     // Error responses
//
//     public ApiResponse<T> BadRequest<T>(string? message = null) where T : class
//
//     {
//
//         return CreateErrorResponse<T>(HttpStatusCode.BadRequest, message);
//
//     }
//
//     public ApiResponse<T> Unauthorized<T>(string? message = null) where T : class
//
//     {
//
//         return CreateErrorResponse<T>(HttpStatusCode.Unauthorized, message);
//
//     }
//
//     public ApiResponse<T> NotFound<T>(string? message = null) where T : class
//
//     {
//
//         return CreateErrorResponse<T>(HttpStatusCode.NotFound, message);
//
//     }
//
//     public ApiResponse<T> UnprocessableEntity<T>(string? message = null) where T : class
//
//     {
//
//         return CreateErrorResponse<T>(HttpStatusCode.UnprocessableEntity, message);
//
//     }
//
//     // Success responses
//
//     public ApiResponse<T> Success<T>(T entity, string? message = null, Dictionary<string, object>? meta = null) where T : class
//
//     {
//
//         return ApiResponse<T>.Success(entity, message, meta);
//
//     }
//
//     public ApiResponse<T> Created<T>(T entity, Dictionary<string, object>? meta = null) where T : class
//
//     {
//
//         return ApiResponse<T>.Created(entity, meta);
//
//     }
//
//     public ApiResponse<T> Deleted<T>(string? message = null) where T : class
//
//     {
//
//         return ApiResponse<T>.Deleted(message);
//
//     }
//
// }
//----------------------------------------------------------------------------------
//
// AuthService
// Handles user authentication, including registration, login, password changes, and token management.
//
// RegisterAsync: Registers a new user.
// LoginAsync: Authenticates a user.
// LogoutAsync: Logs out a user.
// RefreshTokenAsync: Renews an access token.
// ChangePasswordAsync: Updates user password.
// ForgotPasswordAsync: Sends reset password instructions.
// ResetPasswordAsync: Resets password using token.
// VerifyEmailAsync: Confirms email.
// SendVerificationEmailAsync: Sends email verification.
// RevokeTokenAsync: Invalidates a token.
//
// public interface IUserService
// {
//     Task<ApplicationUser> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);
//     Task<ApplicationUser> UpdateUserProfileAsync(string userId, ApplicationUser updatedUser, CancellationToken cancellationToken = default);
//     Task<IList<string>> GetUserRolesAsync(string userId, CancellationToken cancellationToken = default);
//     Task UpdateUserRolesAsync(string userId, IEnumerable<string> roles, CancellationToken cancellationToken = default);
//     Task DeleteUserAsync(string userId, CancellationToken cancellationToken = default);
//     Task<(IEnumerable<ApplicationUser> Users, int TotalCount)> SearchUsersAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
// }
// public interface IStudentService
// {
//     Task<Student> CreateStudentProfileAsync(Student student, CancellationToken cancellationToken = default);
//     Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Student>> GetAllStudentsAsync(CancellationToken cancellationToken = default);
//     Task<Student> UpdateStudentProfileAsync(Student student, CancellationToken cancellationToken = default);
//     Task DeleteStudentProfileAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Course>> GetEnrolledCoursesAsync(Guid studentId, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Progress>> GetStudentProgressAsync(Guid studentId, Guid courseId, CancellationToken cancellationToken = default);
// }
//
// public interface IInstructorService
// {
//     Task<Instructor> CreateInstructorProfileAsync(Instructor instructor, CancellationToken cancellationToken = default);
//     Task<Instructor> GetInstructorByIdAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Instructor>> GetAllInstructorsAsync(CancellationToken cancellationToken = default);
//     Task<Instructor> UpdateInstructorProfileAsync(Guid id, Instructor updatedInstructor, CancellationToken cancellationToken = default);
//     Task DeleteInstructorProfileAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Course>> GetInstructorCoursesAsync(Guid instructorId, CancellationToken cancellationToken = default);
// }
//
// public interface ICourseService
// {
//     Task<Course> CreateCourseAsync(Course course, CancellationToken cancellationToken = default);
//     Task<Course> GetCourseByIdAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<Course> UpdateCourseAsync(Course course, CancellationToken cancellationToken = default);
//     Task DeleteCourseAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Course>> GetCoursesByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Course>> GetCoursesByInstructorAsync(Guid instructorId, CancellationToken cancellationToken = default);
//     Task<(IEnumerable<Course> Courses, int TotalCount)> SearchCoursesAsync(string searchTerm, int pageNumber, int pageSize, CourseLevel? level = null, Guid? categoryId = null, CancellationToken cancellationToken = default);
//     Task<double> GetCourseRatingAsync(Guid courseId, CancellationToken cancellationToken = default);
// }
// public interface ICategoryService
// {
//     Task<Category> CreateCategoryAsync(Category category, CancellationToken cancellationToken = default);
//     Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<Category> UpdateCategoryAsync(Category category, CancellationToken cancellationToken = default);
//     Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
// }
//
// public interface ISectionService
// {
//     Task<Section> CreateSectionAsync(Section section, CancellationToken cancellationToken = default);
//     Task<Section> GetSectionByIdAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<Section> UpdateSectionAsync(Section section, CancellationToken cancellationToken = default);
//     Task DeleteSectionAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Section>> GetSectionsForCourseAsync(Guid courseId, CancellationToken cancellationToken = default);
// }
//
// public interface ILectureService
// {
//     Task<Lecture> CreateLectureAsync(Lecture lecture, CancellationToken cancellationToken = default);
//     Task<Lecture> GetLectureByIdAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<Lecture> UpdateLectureAsync(Lecture lecture, CancellationToken cancellationToken = default);
//     Task DeleteLectureAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Lecture>> GetLecturesForSectionAsync(Guid sectionId, CancellationToken cancellationToken = default);
//     Task<Lecture> AddResourceToLectureAsync(Guid lectureId, LectureResource resource, CancellationToken cancellationToken = default);
//     Task<Lecture> RemoveResourceFromLectureAsync(Guid lectureId, Guid resourceId, CancellationToken cancellationToken = default);
//
// }
// public interface IEnrollmentService
// {
//     Task<Enrollment> EnrollStudentInCourseAsync(Guid studentId, Guid courseId,
//         CancellationToken cancellationToken = default);
//
//     Task UnEnrollStudentFromCourseAsync(Guid studentId, Guid courseId, CancellationToken cancellationToken = default);
//     Task<Enrollment> GetEnrollmentByIdAsync(Guid enrollmentId, CancellationToken cancellationToken = default);
//
//     Task<IEnumerable<Enrollment>> GetEnrollmentsForCourseAsync(Guid courseId,
//         CancellationToken cancellationToken = default);
//
//     Task<IEnumerable<Enrollment>> GetEnrollmentsForStudentAsync(Guid studentId,
//         CancellationToken cancellationToken = default);
//
//     Task<bool> CheckEnrollmentStatusAsync(Guid studentId, Guid courseId, CancellationToken cancellationToken = default);
// }
// public interface IProgressService
// {
//     Task<Progress> UpdateProgressAsync(Guid enrollmentId, Guid lectureId, decimal progressPercentage, ProgressStatus status);
//     Task<decimal> GetProgressForEnrollmentAsync(Guid enrollmentId);
//     Task<decimal> GetOverallCourseProgressAsync(Guid studentId, Guid courseId);
//     Task<Progress> MarkLectureAsCompleteAsync(Guid enrollmentId, Guid lectureId);
//     Task<IEnumerable<Lecture>> GetCompletedLecturesAsync(Guid studentId, Guid courseId);
//     Task<IEnumerable<Progress>> GetProgressDetailsForEnrollmentAsync(Guid enrollmentId);
//     Task<bool> IsLectureCompletedAsync(Guid enrollmentId, Guid lectureId);
//     Task ResetProgressForEnrollmentAsync(Guid enrollmentId);
// }
// public interface IPaymentService
// {
//     Task<Payment> ProcessPaymentAsync(Guid studentId, Guid courseId, decimal amount, string paymentMethod);
//     Task<Payment> GetPaymentByIdAsync(Guid paymentId);
//     Task<Payment> RefundPaymentAsync(Guid paymentId);
//     Task<IEnumerable<Payment>> GetPaymentHistoryAsync(Guid studentId);
//     Task<string> GenerateInvoiceAsync(Guid paymentId);
//     Task<bool> VerifyPaymentAsync(Guid paymentId);
// }
//
// public interface IReviewService
// {
//     Task<Review> CreateReviewAsync(Review review, CancellationToken cancellationToken = default);
//     Task<Review> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<Review> UpdateReviewAsync(Review review, CancellationToken cancellationToken = default);
//     Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Review>> GetReviewsForCourseAsync(Guid courseId, int page = 1, int pageSize = 10, CancellationToken cancellationToken = default);
//     Task<decimal> CalculateAverageRatingAsync(Guid courseId, CancellationToken cancellationToken = default);
// }
//
// public interface IQuizService
// {
//     Task<Quiz> CreateQuizAsync(Quiz quiz, CancellationToken cancellationToken = default);
//     Task<Quiz?> GetQuizByIdAsync(Guid quizId, CancellationToken cancellationToken = default);
//     Task<Quiz> UpdateQuizAsync(Quiz quiz, CancellationToken cancellationToken = default);
//     Task DeleteQuizAsync(Guid quizId, CancellationToken cancellationToken = default);
//     Task<QuizQuestion> AddQuestionToQuizAsync(Guid quizId, QuizQuestion question, CancellationToken cancellationToken = default);
//     Task<QuizQuestion> UpdateQuestionAsync(QuizQuestion question, CancellationToken cancellationToken = default);
//     Task RemoveQuestionFromQuizAsync(Guid quizId, Guid questionId, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Quiz>> GetQuizzesByCourseAsync(Guid courseId, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Quiz>> GetQuizzesBySectionAsync(Guid sectionId, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Quiz>> GetQuizzesByLectureAsync(Guid lectureId, CancellationToken cancellationToken = default);
//     Task<Quiz> GenerateRandomQuizAsync(Guid courseId, int numberOfQuestions, CancellationToken cancellationToken = default);
// }
// public interface IQuizAttemptService
// {
//     Task<QuizAttempt> StartQuizAttemptAsync(Guid studentId, Guid quizId, CancellationToken cancellationToken = default);
//     Task<QuizAttempt> SubmitQuizAttemptAsync(Guid attemptId, IEnumerable<AttemptAnswer> answers, CancellationToken cancellationToken = default);
//     Task<QuizAttempt?> GetQuizAttemptResultAsync(Guid attemptId, CancellationToken cancellationToken = default);
//     Task<IEnumerable<QuizAttempt>> GetQuizAttemptsForStudentAsync(Guid studentId, Guid quizId, CancellationToken cancellationToken = default);
//     Task<IEnumerable<QuizAttempt>> GetQuizAttemptsForQuizAsync(Guid quizId, CancellationToken cancellationToken = default);
//     Task<QuizAttempt> CalculateQuizScoreAsync(Guid attemptId, CancellationToken cancellationToken = default);
//     Task<IEnumerable<QuizAttempt>> GetQuizAttemptHistoryAsync(Guid studentId, CancellationToken cancellationToken = default);
// }
// public interface ISearchService
// {
//     Task<IEnumerable<Course>> SearchCoursesAsync(string searchTerm, CourseLevel? level = null, Guid? categoryId = null, decimal? minPrice = null, decimal? maxPrice = null, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Instructor>> SearchInstructorsAsync(string searchTerm, string? expertise = null, CancellationToken cancellationToken = default);
//     Task<IEnumerable<Lecture>> SearchLecturesAsync(string searchTerm, Guid? courseId = null, CancellationToken cancellationToken = default);
//     Task<(IEnumerable<Course> Courses, IEnumerable<Instructor> Instructors, IEnumerable<Lecture> Lectures)> PerformGlobalSearchAsync(string searchTerm, CancellationToken cancellationToken = default);
//
// }
// public interface IEmailService
// {
//     Task SendWelcomeEmailAsync(string toEmail, string userName);
//     Task SendPasswordResetEmailAsync(string toEmail, string resetToken);
//     Task SendCourseCompletionEmailAsync(string toEmail, string userName, string courseName);
//     Task SendNewCourseNotificationAsync(string toEmail, string courseName, string courseDescription);
// }


// E-Learning Platform API Endpoints
// Authentication
//
// POST /api/auth/register
// POST /api/auth/login
// POST /api/auth/logout
// POST /api/auth/refresh-token
// POST /api/auth/change-password
// POST /api/auth/forgot-password
// POST /api/auth/reset-password
// POST /api/auth/verify-email
// POST /api/auth/send-verification-email
// POST /api/auth/revoke-token
//
// ApplicationUser Management
//
// GET /api/users/{userId}
// PUT /api/users/{userId}
// GET /api/users/{userId}/roles
// PUT /api/users/{userId}/roles
// DELETE /api/users/{userId}
// GET /api/users/search
//
// Student Management
//
// POST /api/students
// GET /api/students/{id}
// GET /api/students
// PUT /api/students/{id}
// DELETE /api/students/{id}
// GET /api/students/{id}/courses
// GET /api/students/{id}/courses/{courseId}/progress
//
// Instructor Management
//
// POST /api/instructors
// GET /api/instructors/{id}
// GET /api/instructors
// PUT /api/instructors/{id}
// DELETE /api/instructors/{id}
// GET /api/instructors/{id}/courses
//
// Course Management
//
// POST /api/courses
// GET /api/courses/{id}
// PUT /api/courses/{id}
// DELETE /api/courses/{id}
// GET /api/courses/category/{categoryId}
// GET /api/courses/instructor/{instructorId}
// GET /api/courses/search
// GET /api/courses/{id}/rating
//
// Category Management
//
// POST /api/categories
// GET /api/categories/{id}
// PUT /api/categories/{id}
// DELETE /api/categories/{id}
// GET /api/categories
//
// Section Management
//
// POST /api/sections
// GET /api/sections/{id}
// PUT /api/sections/{id}
// DELETE /api/sections/{id}
// GET /api/courses/{courseId}/sections
//
// Lecture Management
//
// POST /api/lectures
// GET /api/lectures/{id}
// PUT /api/lectures/{id}
// DELETE /api/lectures/{id}
// GET /api/sections/{sectionId}/lectures
// POST /api/lectures/{id}/resources
// DELETE /api/lectures/{id}/resources/{resourceId}
//
// Enrollment Management
//
// POST /api/enrollments
// DELETE /api/enrollments/{studentId}/{courseId}
// GET /api/enrollments/{id}
// GET /api/courses/{courseId}/enrollments
// GET /api/students/{studentId}/enrollments
// GET /api/enrollments/status/{studentId}/{courseId}
//
// Progress Tracking
//
// PUT /api/progress
// GET /api/enrollments/{enrollmentId}/progress
// GET /api/students/{studentId}/courses/{courseId}/progress
// POST /api/progress/complete-lecture
// GET /api/students/{studentId}/courses/{courseId}/completed-lectures
// GET /api/enrollments/{enrollmentId}/progress-details
// GET /api/enrollments/{enrollmentId}/lectures/{lectureId}/status
// POST /api/enrollments/{enrollmentId}/reset-progress
//
// Payment Management
//
// POST /api/payments
// GET /api/payments/{id}
// POST /api/payments/{id}/refund
// GET /api/students/{studentId}/payment-history
// GET /api/payments/{id}/invoice
// GET /api/payments/{id}/verify
//
// Review Management
//
// POST /api/reviews
// GET /api/reviews/{id}
// PUT /api/reviews/{id}
// DELETE /api/reviews/{id}
// GET /api/courses/{courseId}/reviews
// GET /api/courses/{courseId}/average-rating
//
// Quiz Management
//
// POST /api/quizzes
// GET /api/quizzes/{id}
// PUT /api/quizzes/{id}
// DELETE /api/quizzes/{id}
// POST /api/quizzes/{id}/questions
// PUT /api/quizzes/questions/{questionId}
// DELETE /api/quizzes/{id}/questions/{questionId}
// GET /api/courses/{courseId}/quizzes
// GET /api/sections/{sectionId}/quizzes
// GET /api/lectures/{lectureId}/quizzes
// POST /api/courses/{courseId}/generate-quiz
//
// Quiz Attempt Management
//
// POST /api/quiz-attempts
// PUT /api/quiz-attempts/{id}/submit
// GET /api/quiz-attempts/{id}/result
// GET /api/students/{studentId}/quizzes/{quizId}/attempts
// GET /api/quizzes/{quizId}/attempts
// GET /api/quiz-attempts/{id}/score
// GET /api/students/{studentId}/quiz-history
//
// Search
//
// GET /api/search/courses
// GET /api/search/instructors
// GET /api/search/lectures
// GET /api/search/global
//
// Email Notifications
//
// POST /api/email/welcome
// POST /api/email/password-reset
// POST /api/email/course-completion
// POST /api/email/new-course-notification