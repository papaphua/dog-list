namespace DogList.Domain.Core.Results;

/// <summary>
/// Represents the outcome of an operation, encapsulating success state and error details.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class indicating success.
    /// </summary>
    protected Result()
    {
        IsSuccess = true;
        Error = default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class indicating failure with a specific error.
    /// </summary>
    /// <param name="error">The error details associated with the failure.</param>
    protected Result(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets the error details if the operation was not successful; otherwise, <c>null</c>.
    /// </summary>
    public Error? Error { get; }

    /// <summary>
    /// Implicitly converts an <see cref="Error"/> to a <see cref="Result"/> indicating failure.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    public static implicit operator Result(Error error)
    {
        return new Result(error);
    }

    /// <summary>
    /// Creates a successful <see cref="Result"/>.
    /// </summary>
    /// <returns>A <see cref="Result"/> indicating success.</returns>
    public static Result Success()
    {
        return new Result();
    }

    /// <summary>
    /// Creates a <see cref="Result"/> indicating failure with a specified error.
    /// </summary>
    /// <param name="error">The error details.</param>
    /// <returns>A <see cref="Result"/> indicating failure.</returns>
    public static Result Failure(Error error)
    {
        return new Result(error);
    }
}