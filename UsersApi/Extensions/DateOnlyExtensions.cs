namespace UsersApi.Extensions;

public static class DateOnlyExtensions
{
    public static bool IsNotInFuture(this DateOnly date) => date <= DateOnly.FromDateTime(DateTime.Now);
}