namespace DogList.Domain.Core.Results;

/// <summary>
/// Represents an error with a code, description, and type.
/// </summary>
public sealed class Error
{
    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the description of the error.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the type of the error.
    /// </summary>
    public ErrorType Type { get; }

    /// <summary>
    /// Creates an instance of <see cref="Error"/> for a not found error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">A description of the error.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error NotFound(string code, string description)
    {
        return new Error(code, description, ErrorType.NotFound);
    }

    /// <summary>
    /// Creates an instance of <see cref="Error"/> for a validation error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">A description of the error.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error Validation(string code, string description)
    {
        return new Error(code, description, ErrorType.Validation);
    }

    /// <summary>
    /// Creates an instance of <see cref="Error"/> for a conflict error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">A description of the error.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error Conflict(string code, string description)
    {
        return new Error(code, description, ErrorType.Conflict);
    }

    /// <summary>
    /// Creates an instance of <see cref="Error"/> for an internal error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">A description of the error.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error Internal(string code, string description)
    {
        return new Error(code, description, ErrorType.Internal);
    }
}