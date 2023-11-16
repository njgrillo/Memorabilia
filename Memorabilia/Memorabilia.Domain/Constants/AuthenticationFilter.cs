namespace Memorabilia.Domain.Constants;

public sealed class AuthenticationFilter : Filter<AuthenticationFilter>
{
    public static readonly AuthenticationFilter None = new("None");
    public static readonly AuthenticationFilter NotAuthenticated = new("Not Authenticated");
    public static readonly AuthenticationFilter Authenticated = new("Authenticated");

    private AuthenticationFilter(string name)
        : base(name) { }

    public static readonly AuthenticationFilter[] All =
    [
        None,
        NotAuthenticated,
        Authenticated
    ];

    public static readonly AuthenticationFilter[] FilterItems =
    [
        NotAuthenticated,
        Authenticated
    ];
}
