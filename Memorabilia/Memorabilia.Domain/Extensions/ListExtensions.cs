namespace Memorabilia.Domain.Extensions;

public static class ListExtensions
{
    public static bool HasAny<T>(this IList<T> value)
        => value is not null && value.Count > 0;

    public static bool IsEmpty<T>(this IList<T> value)
        => value is not null && value.Count == 0;

    public static bool IsNullOrEmpty<T>(this IList<T> value)
        => value is null || value.Count == 0;
}
