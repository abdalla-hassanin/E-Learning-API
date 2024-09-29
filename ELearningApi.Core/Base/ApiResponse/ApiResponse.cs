using System.Net;

namespace ELearningApi.Core.Base.ApiResponse;

public class ApiResponse<T> where T : class
{
    // HTTP status code of the response
    public HttpStatusCode StatusCode { get; set; }

    // Additional metadata related to the response
    public Dictionary<string, object>? Meta { get; set; }

    // Indicates whether the request was successful
    public bool Succeeded { get; set; }

    // Message providing additional information about the response
    public string? Message { get; set; }

    // List of errors encountered during the request
    public List<string> Errors { get; set; } = new List<string>();

    // Data payload of the response
    public T? Data { get; set; }

    // Static factory methods to create responses

    // Success response
    public static ApiResponse<T> Success(T data, string? message = null, Dictionary<string, object>? meta = null) => new ApiResponse<T>
    {
        Data = data,
        Succeeded = true,
        StatusCode = HttpStatusCode.OK,
        Message = message,
        Meta = meta
    };

    // Created response
    public static ApiResponse<T> Created(T data, Dictionary<string, object>? meta = null) => new ApiResponse<T>
    {
        Data = data,
        Succeeded = true,
        StatusCode = HttpStatusCode.Created,
        Meta = meta
    };

    // Error response
    public static ApiResponse<T> Error(HttpStatusCode statusCode, string? message, List<string>? errors = null) => new ApiResponse<T>
    {
        Succeeded = false,
        StatusCode = statusCode,
        Message = message,
        Errors = errors ?? new List<string>()
    };

    // Deleted response
    public static ApiResponse<T> Deleted(string? message = null) => new ApiResponse<T>
    {
        Succeeded = true,
        StatusCode = HttpStatusCode.OK,
        Message = message
    };
}
