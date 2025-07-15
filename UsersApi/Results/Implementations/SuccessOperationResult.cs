using UsersApi.Results.Interfaces;

namespace UsersApi.Results.Implementations;

public sealed class SuccessOperationResult<T>(T value) : IOperationResult
{
    public T Value { get; } = value;
    public bool IsSuccess => true;
}