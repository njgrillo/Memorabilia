namespace Memorabilia.Domain.Extensions;

public static class DateTimeExtensions
{
    public static bool IsActive(this DateTime? date)
        => !date.HasValue || date > DateTime.UtcNow;

    public static bool IsExpired(this DateTime? date)
        => date.HasValue && date < DateTime.UtcNow;
}
