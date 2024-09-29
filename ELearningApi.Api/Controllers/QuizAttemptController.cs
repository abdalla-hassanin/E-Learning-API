using ELearningApi.Api.Base;
using ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.CalculateQuizScore;
using ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.StartQuizAttempt;
using ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.SubmitQuizAttempt;
using ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptHistory;
using ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptResult;
using ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptsForQuiz;
using ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptsForStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for quiz attempt operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class QuizAttemptController : AppControllerBase
{
    /// <summary>
    /// Starts a new quiz attempt for a student.
    /// </summary>
    /// <param name="command">The start quiz attempt command.</param>
    /// <returns>The created quiz attempt.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/QuizAttempt/start
    ///     {
    ///         "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Quiz attempt started successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "startTime": "2023-06-07T10:00:00Z",
    ///             "endTime": null,
    ///             "score": 0,
    ///             "isPassed": false,
    ///             "answers": []
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Student")]
    [HttpPost("start")]
    public async Task<IActionResult> StartQuizAttempt([FromBody] StartQuizAttemptCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Submits a quiz attempt with the student's answers.
    /// </summary>
    /// <param name="command">The submit quiz attempt command.</param>
    /// <returns>The submitted quiz attempt with results.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/QuizAttempt/submit
    ///     {
    ///         "attemptId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///         "answers": [
    ///             {
    ///                 "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                 "response": "3fa85f64-5717-4562-b3fc-2c963f66afaa"
    ///             },
    ///             {
    ///                 "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
    ///                 "response": "True"
    ///             }
    ///         ]
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Quiz attempt submitted successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "startTime": "2023-06-07T10:00:00Z",
    ///             "endTime": "2023-06-07T10:30:00Z",
    ///             "score": 75,
    ///             "isPassed": true,
    ///             "answers": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afac",
    ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                     "response": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
    ///                     "isCorrect": true,
    ///                     "pointsEarned": 10,
    ///                     "timeTaken": "00:05:00"
    ///                 },
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afad",
    ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
    ///                     "response": "True",
    ///                     "isCorrect": false,
    ///                     "pointsEarned": 0,
    ///                     "timeTaken": "00:03:00"
    ///                 }
    ///             ]
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Student")]
    [HttpPost("submit")]
    public async Task<IActionResult> SubmitQuizAttempt([FromBody] SubmitQuizAttemptCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Calculates the score for a quiz attempt.
    /// </summary>
    /// <param name="attemptId">The ID of the quiz attempt.</param>
    /// <returns>The quiz attempt with calculated score.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/QuizAttempt/3fa85f64-5717-4562-b3fc-2c963f66afa8/calculate-score
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Quiz score calculated successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "startTime": "2023-06-07T10:00:00Z",
    ///             "endTime": "2023-06-07T10:30:00Z",
    ///             "score": 75,
    ///             "isPassed": true,
    ///             "answers": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afac",
    ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                     "response": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
    ///                     "isCorrect": true,
    ///                     "pointsEarned": 10,
    ///                     "timeTaken": "00:05:00"
    ///                 },
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afad",
    ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
    ///                     "response": "True",
    ///                     "isCorrect": false,
    ///                     "pointsEarned": 0,
    ///                     "timeTaken": "00:03:00"
    ///                 }
    ///             ]
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost("{attemptId}/calculate-score")]
    public async Task<IActionResult> CalculateQuizScore(Guid attemptId)
    {
        var command = new CalculateQuizScoreCommand { AttemptId = attemptId };
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves the result of a specific quiz attempt.
    /// </summary>
    /// <param name="attemptId">The ID of the quiz attempt.</param>
    /// <returns>The quiz attempt result.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/QuizAttempt/3fa85f64-5717-4562-b3fc-2c963f66afa8/result
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "startTime": "2023-06-07T10:00:00Z",
    ///             "endTime": "2023-06-07T10:30:00Z",
    ///             "score": 75,
    ///             "isPassed": true,
    ///             "answers": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afac",
    ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                     "response": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
    ///                     "isCorrect": true,
    ///                     "pointsEarned": 10,
    ///                     "timeTaken": "00:05:00"
    ///                 },
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afad",
    ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
    ///                     "response": "True",
    ///                     "isCorrect": false,
    ///                     "pointsEarned": 0,
    ///                     "timeTaken": "00:03:00"
    ///                 }
    ///             ]
    ///         }
    ///     }
    /// </remarks>
    [HttpGet("{attemptId}/result")]
    public async Task<IActionResult> GetQuizAttemptResult(Guid attemptId)
    {
        var query = new GetQuizAttemptResultQuery { AttemptId = attemptId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all quiz attempts for a specific student and quiz.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <param name="quizId">The ID of the quiz.</param>
    /// <returns>A list of quiz attempts for the specified student and quiz.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/QuizAttempt/student/3fa85f64-5717-4562-b3fc-2c963f66afa6/quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "startTime": "2023-06-07T10:00:00Z",
    ///                 "endTime": "2023-06-07T10:30:00Z",
    ///                 "score": 75,
    ///                 "isPassed": true,
    ///                 "answers": []
    ///             },
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "startTime": "2023-06-08T14:00:00Z",
    ///                 "endTime": "2023-06-08T14:25:00Z",
    ///                 "score": 90,
    ///                 "isPassed": true,
    ///                 "answers": []
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("student/{studentId}/quiz/{quizId}")]
    public async Task<IActionResult> GetQuizAttemptsForStudent(Guid studentId, Guid quizId)
    {
        var query = new GetQuizAttemptsForStudentQuery { StudentId = studentId, QuizId = quizId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all quiz attempts for a specific quiz.
    /// </summary>
    /// <param name="quizId">The ID of the quiz.</param>
    /// <returns>A list of all quiz attempts for the specified quiz.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/QuizAttempt/quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "startTime": "2023-06-07T10:00:00Z",
    ///                 "endTime": "2023-06-07T10:30:00Z",
    ///                 "score": 75,
    ///                 "isPassed": true,
    ///                 "answers": []
    ///             },
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
    ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "startTime": "2023-06-08T14:00:00Z",
    ///                 "endTime": "2023-06-08T14:25:00Z",
    ///                 "score": 90,
    ///                 "isPassed": true,
    ///                 "answers": []
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpGet("quiz/{quizId}")]
    public async Task<IActionResult> GetQuizAttemptsForQuiz(Guid quizId)
    {
        var query = new GetQuizAttemptsForQuizQuery { QuizId = quizId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves the quiz attempt history for a specific student.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <returns>A list of all quiz attempts for the specified student.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/QuizAttempt/history/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "startTime": "2023-06-07T10:00:00Z",
    ///                 "endTime": "2023-06-07T10:30:00Z",
    ///                 "score": 75,
    ///                 "isPassed": true,
    ///                 "answers": []
    ///             },
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
    ///                 "startTime": "2023-06-08T14:00:00Z",
    ///                 "endTime": "2023-06-08T14:25:00Z",
    ///                 "score": 90,
    ///                 "isPassed": true,
    ///                 "answers": []
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("history/{studentId}")]
    public async Task<IActionResult> GetQuizAttemptHistory(Guid studentId)
    {
        var query = new GetQuizAttemptHistoryQuery { StudentId = studentId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }
}