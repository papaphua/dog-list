﻿using System.Net;
using DogList.Domain.Core.Results;
using Microsoft.AspNetCore.Http;

namespace DogList.Presentation.Core;

/// <summary>
///     Provides extension methods for converting <see cref="Result" /> instances into HTTP problem details.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    ///     Converts a <see cref="Result" /> instance into an <see cref="IResult" /> representing the result of an HTTP
    ///     endpoint.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns>An <see cref="IResult" /> containing the result of an HTTP endpoint.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the result is not failure.</exception>
    public static IResult ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException();

        return Results.Problem(
            statusCode: GetStatusCode(result.Error!.Type),
            title: GetTitle(result.Error.Type),
            type: GetType(result.Error.Type),
            extensions: new Dictionary<string, object?>
            {
                { "errors", new[] { result.Error } }
            });
    }

    private static int GetStatusCode(ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.Validation => (int)HttpStatusCode.BadRequest,
            ErrorType.NotFound => (int)HttpStatusCode.NotFound,
            ErrorType.Conflict => (int)HttpStatusCode.Conflict,
            ErrorType.Internal => (int)HttpStatusCode.InternalServerError,
            _ => (int)HttpStatusCode.InternalServerError
        };
    }

    private static string GetTitle(ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.Validation => HttpStatusCode.BadRequest.ToString(),
            ErrorType.NotFound => HttpStatusCode.NotFound.ToString(),
            ErrorType.Conflict => HttpStatusCode.Conflict.ToString(),
            ErrorType.Internal => HttpStatusCode.InternalServerError.ToString(),
            _ => HttpStatusCode.InternalServerError.ToString()
        };
    }

    private static string GetType(ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            ErrorType.Conflict => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
            ErrorType.Internal => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
        };
    }
}