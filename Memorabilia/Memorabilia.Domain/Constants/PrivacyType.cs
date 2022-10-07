namespace Memorabilia.Domain.Constants;

public sealed class PrivacyType : DomainItemConstant
{
    public static readonly PrivacyType Public = new(1, "Public");
    public static readonly PrivacyType Private = new(2, "Private");

    public static readonly PrivacyType[] All =
    {
        Public,
        Private
    };

    private PrivacyType(int id, string name) : base(id, name) { }

    public static PrivacyType Find(int id)
    {
        return All.SingleOrDefault(privacyType => privacyType.Id == id);
    }
}
