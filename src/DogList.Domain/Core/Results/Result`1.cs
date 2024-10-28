namespace DogList.Domain.Core.Results;

/// <summary>
///     Represents the outcome of an operation that can return a value of type <typeparamref name="TValue" />.
///     Inherits from <see cref="Result" /> to include error handling.
/// </summary>
/// <typeparam name="TValue">The type of the value returned upon success.</typeparam>
public sealed class Result<TValue> : Result
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Result{TValue}" /> class with a specified value.
    /// </summary>
    /// <param name="value">The value to be returned upon success.</param>
    private Result(TValue value)
    {
        Value = value;
    }

    private Result(Error error) : base(error)
    {
        Value = default;
    }

    /// <summary>
    ///     Gets the value returned upon success; otherwise, <c>null</c>.
    /// </summary>
    public TValue? Value { get; }

    /// <summary>
    ///     Implicitly converts an <see cref="Error" /> to a <see cref="Result{TValue}" /> indicating failure.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    public static implicit operator Result<TValue>(Error error)
    {
        return new Result<TValue>(error);
    }

    /// <summary>
    ///     Implicitly converts a value of type <typeparamref name="TValue" /> to a <see cref="Result{TValue}" /> indicating
    ///     success.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator Result<TValue>(TValue value)
    {
        return new Result<TValue>(value);
    }

    /// <summary>
    ///     Creates a successful <see cref="Result{TValue}" /> with the specified value.
    /// </summary>
    /// <param name="value">The value to return upon success.</param>
    /// <returns>A <see cref="Result{TValue}" /> indicating success.</returns>
    public static Result<TValue> Success(TValue value)
    {
        return new Result<TValue>(value);
    }

    /// <summary>
    ///     Creates a <see cref="Result{TValue}" /> indicating failure with a specified error.
    /// </summary>
    /// <param name="error">The error details.</param>
    /// <returns>A <see cref="Result{TValue}" /> indicating failure.</returns>
    public new static Result<TValue> Failure(Error error)
    {
        return new Result<TValue>(error);
    }
}