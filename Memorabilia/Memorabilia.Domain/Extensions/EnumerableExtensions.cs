namespace Memorabilia.Domain.Extensions;

public static class EnumerableExtensions
{
    public static bool HasAny<T>(this IEnumerable<T> value)
        => value is not null && value.Any();

    public static bool IsEmpty<T>(this IEnumerable<T> value)
        => value is not null && !value.Any();

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
        => value is null || !value.Any();
}
