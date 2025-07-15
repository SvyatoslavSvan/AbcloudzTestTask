using UsersApi.Results.Interfaces;

namespace UsersApi.Results.Implementations;

public sealed class ErrorOperationResult(string message) : IOperationResult
{
    public string Message { get; } = message;
    public bool IsSuccess => false;
}