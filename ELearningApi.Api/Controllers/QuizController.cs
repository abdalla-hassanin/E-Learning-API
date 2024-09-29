using ELearningApi.Api.Base;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Quiz;
using ELearningApi.Core.MediatrHandlers.Quiz.Commands.AddQuestionToQuiz;
using ELearningApi.Core.MediatrHandlers.Quiz.Commands.CreateQuiz;
using ELearningApi.Core.MediatrHandlers.Quiz.Commands.DeleteQuiz;
using ELearningApi.Core.MediatrHandlers.Quiz.Commands.GenerateRandomQuiz;
using ELearningApi.Core.MediatrHandlers.Quiz.Commands.RemoveQuestionFromQuiz;
using ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuestion;
using ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuiz;
using ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizById;
using ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByCourse;
using ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByLecture;
using ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesBySection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for managing quizzes and quiz questions.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class QuizController : AppControllerBase
{
    /// <summary>
    /// Creates a new quiz.
    /// </summary>
    /// <param name="command">The create quiz command.</param>
    /// <returns>The created quiz.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Quiz
    ///     {
    ///         "title": "Introduction to C# Quiz",
    ///         "description": "Test your knowledge of C# basics",
    ///         "type": 0,
    ///         "timeLimit": 30,
    ///         "passingScore": 70,
    ///         "isRandomized": true,
    ///         "showCorrectAnswers": false,
    ///         "maxAttempts": 2,
    ///         "availableFrom": "2023-06-01T00:00:00Z",
    ///         "availableTo": "2023-12-31T23:59:59Z",
    ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Quiz created successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "title": "Introduction to C# Quiz",
    ///             "description": "Test your knowledge of C# basics",
    ///             "type": 0,
    ///             "timeLimit": 30,
    ///             "passingScore": 70,
    ///             "isRandomized": true,
    ///             "showCorrectAnswers": false,
    ///             "maxAttempts": 2,
    ///             "availableFrom": "2023-06-01T00:00:00Z",
    ///             "availableTo": "2023-12-31T23:59:59Z",
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "questions": []
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves a quiz by its ID.
    /// </summary>
    /// <param name="id">The ID of the quiz to retrieve.</param>
    /// <returns>The requested quiz.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "title": "Introduction to C# Quiz",
    ///             "description": "Test your knowledge of C# basics",
    ///             "type": 0,
    ///             "timeLimit": 30,
    ///             "passingScore": 70,
    ///             "isRandomized": true,
    ///             "showCorrectAnswers": false,
    ///             "maxAttempts": 2,
    ///             "availableFrom": "2023-06-01T00:00:00Z",
    ///             "availableTo": "2023-12-31T23:59:59Z",
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "questions": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                     "questionText": "What is a namespace in C#?",
    ///                     "type": 0,
    ///                     "points": 10,
    ///                     "difficultyLevel": 2,
    ///                     "explanation": "A namespace is used to organize and provide a level of separation of code elements.",
    ///                     "orderIndex": 1,
    ///                     "answers": [
    ///                         {
    ///                             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                             "answerText": "A container for classes and other namespaces",
    ///                             "isCorrect": true,
    ///                             "explanation": "This is the correct definition of a namespace in C#.",
    ///                             "orderIndex": 1
    ///                         },
    ///                         {
    ///                             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb0",
    ///                             "answerText": "A type of variable",
    ///                             "isCorrect": false,
    ///                             "explanation": "This is incorrect. A namespace is not a type of variable.",
    ///                             "orderIndex": 2
    ///                         }
    ///                     ],
    ///                     "media": []
    ///                 }
    ///             ]
    ///         }
    ///     }
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuizById(Guid id)
    {
        var query = new GetQuizByIdQuery { QuizId = id };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Updates an existing quiz.
    /// </summary>
    /// <param name="id">The ID of the quiz to update.</param>
    /// <param name="command">The update quiz command.</param>
    /// <returns>The updated quiz.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///     {
    ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///         "title": "Updated C# Quiz",
    ///         "description": "Updated test of C# knowledge",
    ///         "type": 1,
    ///         "timeLimit": 45,
    ///         "passingScore": 75,
    ///         "isRandomized": false,
    ///         "showCorrectAnswers": true,
    ///         "maxAttempts": 3,
    ///         "availableFrom": "2023-07-01T00:00:00Z",
    ///         "availableTo": "2024-06-30T23:59:59Z",
    ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Quiz updated successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "title": "Updated C# Quiz",
    ///             "description": "Updated test of C# knowledge",
    ///             "type": 1,
    ///             "timeLimit": 45,
    ///             "passingScore": 75,
    ///             "isRandomized": false,
    ///             "showCorrectAnswers": true,
    ///             "maxAttempts": 3,
    ///             "availableFrom": "2023-07-01T00:00:00Z",
    ///             "availableTo": "2024-06-30T23:59:59Z",
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "questions": []
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuiz(Guid id, [FromBody] UpdateQuizCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Deletes a quiz.
    /// </summary>
    /// <param name="id">The ID of the quiz to delete.</param>
    /// <returns>A success message if the quiz was deleted.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Quiz deleted successfully.",
    ///         "data": "Quiz deleted successfully."
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuiz(Guid id)
    {
        var command = new DeleteQuizCommand { Id = id };
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Adds a question to a quiz.
    /// </summary>
    /// <param name="quizId">The ID of the quiz to add the question to.</param>
    /// <param name="command">The add question command.</param>
    /// <returns>The added question.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7/question
    ///     {
    ///         "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///         "question": {
    ///             "questionText": "What is inheritance in C#?",
    ///             "type": 0,
    ///             "points": 15,
    ///             "difficultyLevel": 3,
    ///             "explanation": "Inheritance is a mechanism in C# that allows a class to inherit properties and methods from another class.",
    ///             "orderIndex": 2,
    ///             "answers": [
    ///                 {
    ///                     "answerText": "A mechanism for code reuse",
    ///                     "isCorrect": true,
    ///                     "explanation": "This is correct. Inheritance is primarily used for code reuse.",
    ///                     "orderIndex": 1
    ///                 },
    ///                 {
    ///                     "answerText": "A way to create multiple instances of a class",
    ///                     "isCorrect": false,
    ///                     "explanation": "This is incorrect. Creating multiple instances is not related to inheritance.",
    ///                     "orderIndex": 2
    ///                 }
    ///             ]
    ///         }
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Question added to quiz successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb1",
    ///             "questionText": "What is inheritance in C#?",
    ///             "type": 0,
    ///             "points": 15,
    ///             "difficultyLevel": 3,
    ///             "explanation": "Inheritance is a mechanism in C# that allows a class to inherit properties and methods from another class.",
    ///             "orderIndex": 2,
    ///             "answers": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb2",
    ///                     "answerText": "A mechanism for code reuse",
    ///                     "isCorrect": true,
    ///                     "explanation": "This is correct. Inheritance is primarily used for code reuse.",
    ///                     "orderIndex": 1
    ///                 },
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb3",
    ///                     "answerText": "A way to create multiple instances of a class",
    ///                     "isCorrect": false,
    ///                     "explanation": "This is incorrect. Creating multiple instances is not related to inheritance.",
    ///                     "orderIndex": 2
    ///                 }
    ///             ],
    ///             "media": []
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost("{quizId}/question")]
    public async Task<IActionResult> AddQuestionToQuiz(Guid quizId, [FromBody] AddQuestionToQuizCommand command)
    {
        if (quizId != command.QuizId)
        {
            return BadRequest("The quiz ID in the URL does not match the quiz ID in the request body.");
        }
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Updates a question in a quiz.
    /// </summary>
    /// <param name="quizId">The ID of the quiz containing the question.</param>
    /// <param name="questionId">The ID of the question to update.</param>
    /// <param name="command">The update question command.</param>
    /// <returns>The updated question.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7/question/3fa85f64-5717-4562-b3fc-2c963f66afb1
    ///     {
    ///         "question": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb1",
    ///             "questionText": "What is the primary purpose of inheritance in C#?",
    ///             "type": 0,
    ///             "points": 20,
    ///             "difficultyLevel": 3,
    ///             "explanation": "Inheritance is a fundamental concept in object-oriented programming that allows for code reuse and the creation of class hierarchies.",
    ///             "orderIndex": 2,
    ///             "answers": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb2",
    ///                     "answerText": "To enable code reuse and create class hierarchies",
    ///                     "isCorrect": true,
    ///                     "explanation": "This is the primary purpose of inheritance in C#.",
    ///                     "orderIndex": 1
    ///                 },
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb3",
    ///                     "answerText": "To create multiple instances of a class",
    ///                     "isCorrect": false,
    ///                     "explanation": "This is not the primary purpose of inheritance.",
    ///                     "orderIndex": 2
    ///                 }
    ///             ]
    ///         }
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Question updated successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb1",
    ///             "questionText": "What is the primary purpose of inheritance in C#?",
    ///             "type": 0,
    ///             "points": 20,
    ///             "difficultyLevel": 3,
    ///             "explanation": "Inheritance is a fundamental concept in object-oriented programming that allows for code reuse and the creation of class hierarchies.",
    ///             "orderIndex": 2,
    ///             "answers": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb2",
    ///                     "answerText": "To enable code reuse and create class hierarchies",
    ///                     "isCorrect": true,
    ///                     "explanation": "This is the primary purpose of inheritance in C#.",
    ///                     "orderIndex": 1
    ///                 },
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb3",
    ///                     "answerText": "To create multiple instances of a class",
    ///                     "isCorrect": false,
    ///                     "explanation": "This is not the primary purpose of inheritance.",
    ///                     "orderIndex": 2
    ///                 }
    ///             ],
    ///             "media": []
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPut("{quizId}/question/{questionId}")]
    public async Task<IActionResult> UpdateQuestion(Guid quizId, Guid questionId, [FromBody] UpdateQuestionCommand command)
    {
        if (questionId != command.Question.Id)
        {
            return BadRequest("The question ID in the URL does not match the question ID in the request body.");
        }
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Removes a question from a quiz.
    /// </summary>
    /// <param name="quizId">The ID of the quiz containing the question.</param>
    /// <param name="questionId">The ID of the question to remove.</param>
    /// <returns>A success message if the question was removed.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7/question/3fa85f64-5717-4562-b3fc-2c963f66afb1
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Question removed from quiz successfully.",
    ///         "data": "Question removed from quiz successfully."
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpDelete("{quizId}/question/{questionId}")]
    public async Task<IActionResult> RemoveQuestionFromQuiz(Guid quizId, Guid questionId)
    {
        var command = new RemoveQuestionFromQuizCommand { QuizId = quizId, QuestionId = questionId };
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all quizzes for a specific course.
    /// </summary>
    /// <param name="courseId">The ID of the course.</param>
    /// <returns>A list of quizzes for the specified course.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Quiz/course/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "title": "C# Basics Quiz",
    ///                 "description": "Test your knowledge of C# fundamentals",
    ///                 "type": 0,
    ///                 "timeLimit": 30,
    ///                 "passingScore": 70,
    ///                 "isRandomized": true,
    ///                 "showCorrectAnswers": false,
    ///                 "maxAttempts": 2,
    ///                 "availableFrom": "2023-06-01T00:00:00Z",
    ///                 "availableTo": "2023-12-31T23:59:59Z",
    ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "questions": []
    ///             },
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                 "title": "Advanced C# Concepts",
    ///                 "description": "Challenge yourself with advanced C# topics",
    ///                 "type": 1,
    ///                 "timeLimit": 45,
    ///                 "passingScore": 80,
    ///                 "isRandomized": false,
    ///                 "showCorrectAnswers": true,
    ///                 "maxAttempts": 3,
    ///                 "availableFrom": "2023-07-01T00:00:00Z",
    ///                 "availableTo": "2023-12-31T23:59:59Z",
    ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "questions": []
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetQuizzesByCourse(Guid courseId)
    {
        var query = new GetQuizzesByCourseQuery { CourseId = courseId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all quizzes for a specific section.
    /// </summary>
    /// <param name="sectionId">The ID of the section.</param>
    /// <returns>A list of quizzes for the specified section.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Quiz/section/3fa85f64-5717-4562-b3fc-2c963f66afa9
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
    ///                 "title": "Section 1 Quiz",
    ///                 "description": "Test your knowledge of Section 1 content",
    ///                 "type": 0,
    ///                 "timeLimit": 20,
    ///                 "passingScore": 75,
    ///                 "isRandomized": true,
    ///                 "showCorrectAnswers": false,
    ///                 "maxAttempts": 2,
    ///                 "availableFrom": "2023-06-01T00:00:00Z",
    ///                 "availableTo": "2023-12-31T23:59:59Z",
    ///                 "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                 "questions": []
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("section/{sectionId}")]
    public async Task<IActionResult> GetQuizzesBySection(Guid sectionId)
    {
        var query = new GetQuizzesBySectionQuery { SectionId = sectionId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all quizzes for a specific lecture.
    /// </summary>
    /// <param name="lectureId">The ID of the lecture.</param>
    /// <returns>A list of quizzes for the specified lecture.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Quiz/lecture/3fa85f64-5717-4562-b3fc-2c963f66afab
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afac",
    ///                 "title": "Lecture Quiz",
    ///                 "description": "Quick quiz on lecture content",
    ///                 "type": 0,
    ///                 "timeLimit": 10,
    ///                 "passingScore": 80,
    ///                 "isRandomized": false,
    ///                 "showCorrectAnswers": true,
    ///                 "maxAttempts": 1,
    ///                 "availableFrom": "2023-06-01T00:00:00Z",
    ///                 "availableTo": "2023-12-31T23:59:59Z",
    ///                 "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
    ///                 "questions": []
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("lecture/{lectureId}")]
    public async Task<IActionResult> GetQuizzesByLecture(Guid lectureId)
    {
        var query = new GetQuizzesByLectureQuery { LectureId = lectureId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Generates a random quiz for a specific course.
    /// </summary>
    /// <param name="courseId">The ID of the course.</param>
    /// <param name="questionCount">The number of questions to include in the random quiz.</param>
    /// <returns>The generated random quiz.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Quiz/random?courseId=3fa85f64-5717-4562-b3fc-2c963f66afa6&amp;questionCount=5
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Random quiz generated successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afad",
    ///             "title": "Random Quiz",
    ///             "description": "Randomly generated quiz",
    ///             "type": 0,
    ///             "timeLimit": null,
    ///             "passingScore": 0,
    ///             "isRandomized": true,
    ///             "showCorrectAnswers": false,
    ///             "maxAttempts": 1,
    ///             "availableFrom": "2023-06-07T00:00:00Z",
    ///             "availableTo": null,
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "questions": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afae",
    ///                     "questionText": "What is a namespace in C#?",
    ///                     "type": 0,
    ///                     "points": 10,
    ///                     "difficultyLevel": 2,
    ///                     "explanation": "A namespace is used to organize and provide a level of separation of code elements.",
    ///                     "orderIndex": 1,
    ///                     "answers": [
    ///                         {
    ///                             "id": "3fa85f64-5717-4562-b3fc-2c963f66afaf",
    ///                             "answerText": "A container for classes and other namespaces",
    ///                             "isCorrect": true,
    ///                             "explanation": "This is the correct definition of a namespace in C#.",
    ///                             "orderIndex": 1
    ///                         },
    ///                         {
    ///                             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb0",
    ///                             "answerText": "A type of variable",
    ///                             "isCorrect": false,
    ///                             "explanation": "This is incorrect. A namespace is not a type of variable.",
    ///                             "orderIndex": 2
    ///                         }
    ///                     ],
    ///                     "media": []
    ///                 },
    ///                 // ... more questions ...
    ///             ]
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost("random")]
    public async Task<IActionResult> GenerateRandomQuiz([FromQuery] Guid courseId, [FromQuery] int questionCount)
    {
        var command = new GenerateRandomQuizCommand { CourseId = courseId, QuestionCount = questionCount };
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }
}