namespace Memorabilia.Domain.Extensions;

public static class IntegerExtensions
{
    public static bool IsBetween(this int value, int min, int? max)
        => value >= min && (!max.HasValue || value <= max);

    public static string ToMonth(this int value)
        => value > 0 && value < 13
            ? new DateOnly(2000, value, 1).ToString("MMMM")
            : string.Empty;

    public static string ToMonth(this int? value)
        => value.HasValue
            ? new DateOnly(2000, value.Value, 1).ToString("MMMM")
            : string.Empty;

    public static int? ToNullableInt(this int value)
        => value > 0
            ? value
            : null;
}
