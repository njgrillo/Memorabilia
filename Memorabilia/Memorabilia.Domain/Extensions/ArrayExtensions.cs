namespace Memorabilia.Domain.Extensions;

public static class ArrayExtensions
{
    public static bool HasAny<T>(this T[] value)
        => value is not null && value.Length > 0;

    public static bool IsEmpty<T>(this T[] value)
        => value is not null && value.Length == 0;

    public static bool IsNullOrEmpty<T>(this T[] value)
        => value is null || value.Length == 0;
}
