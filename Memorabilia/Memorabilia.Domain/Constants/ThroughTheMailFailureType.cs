namespace Memorabilia.Domain.Constants;

public sealed class ThroughTheMailFailureType : DomainItemConstant
{
    public static readonly ThroughTheMailFailureType IncorrectAddress = new(1, "Incorrect Address");
    public static readonly ThroughTheMailFailureType RefusedToSign = new(2, "Refused to Sign");
    public static readonly ThroughTheMailFailureType RequestedFee = new(3, "Requested Fee/Donation");

    public static readonly ThroughTheMailFailureType[] All =
    [
        IncorrectAddress,
        RefusedToSign,
        RequestedFee
    ];

    private ThroughTheMailFailureType(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static ThroughTheMailFailureType Find(int id)
        => All.SingleOrDefault(type => type.Id == id);

    public static ThroughTheMailFailureType Find(string name)
        => All.SingleOrDefault(type => type.Name == name);
}
