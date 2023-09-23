namespace Memorabilia.Domain.Constants;

public sealed class LoginProvider : DomainItemConstant
{
    public static readonly LoginProvider Google = new(1, "Google");
    public static readonly LoginProvider Meta = new(2, "Meta", "Facebook");
    public static readonly LoginProvider Microsoft = new(3, "Microsoft");
    public static readonly LoginProvider X = new(4, "X", "Twitter");

    public static readonly LoginProvider[] All =
    {
        Google,
        Meta,
        Microsoft,
        X
    };

    public string LegacyName { get; private set; }

    public string LoginPageName { get; private set; }

    private LoginProvider(int id, string name, string legacyName = null, string abbreviation = null)
        : base(id, name, abbreviation) 
    {
        LegacyName = legacyName;
    }

    public static LoginProvider Find(int id)
        => All.SingleOrDefault(loginProvider => loginProvider.Id == id);

    public static LoginProvider Find(string name)
        => All.SingleOrDefault(loginProvider => loginProvider.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                                             || (!loginProvider.LegacyName.IsNullOrEmpty() && loginProvider.LegacyName.Equals(name, StringComparison.OrdinalIgnoreCase)));
}
