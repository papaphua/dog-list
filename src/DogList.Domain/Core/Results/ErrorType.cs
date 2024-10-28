namespace DogList.Domain.Core.Results;

/// <summary>
///     Represents the type of error with corresponding HTTP status codes.
/// </summary>
public enum ErrorType
{
    /// <summary>
    ///     Represents a "Not Found" error (HTTP 404).
    /// </summary>
    NotFound = 404,

    /// <summary>
    ///     Represents a "Validation" error (HTTP 400).
    /// </summary>
    Validation = 400,

    /// <summary>
    ///     Represents a "Conflict" error (HTTP 409).
    /// </summary>
    Conflict = 409,

    /// <summary>
    ///     Represents an "Internal Server Error" (HTTP 500).
    /// </summary>
    Internal = 500
}