namespace Memorabilia.Domain.Extensions;

public static class BooleanExtensions
{
    public static int ToInt32(this bool value)
        => value ? 1 : 0;
}
