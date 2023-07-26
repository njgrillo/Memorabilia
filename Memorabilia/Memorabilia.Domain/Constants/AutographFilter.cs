namespace Memorabilia.Domain.Constants;

public class AutographFilter : Filter<AutographFilter>
{
    public static readonly AutographFilter None = new("None");
    public static readonly AutographFilter WithAutographs = new("With Autograph(s)");
    public static readonly AutographFilter WithoutAutographs = new("Without Autograph(s)");

    private AutographFilter(string name)
        : base(name) { }

    public static readonly AutographFilter[] All =
    {
        None,
        WithAutographs,
        WithoutAutographs
    };

    public static readonly AutographFilter[] FilterItems =
    {
        WithAutographs,
        WithoutAutographs
    };
}
