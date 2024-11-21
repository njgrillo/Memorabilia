namespace Memorabilia.Domain.Constants;

public sealed class PrivateSigningStatus : DomainItemConstant
{    
    public static readonly PrivateSigningStatus Completed = new(2, "Completed");
    public static readonly PrivateSigningStatus InProgress = new(4, "In Progress");
    public static readonly PrivateSigningStatus OnHold = new(3, "On Hold");
    public static readonly PrivateSigningStatus Pending = new(1, "Pending");

    public static readonly PrivateSigningStatus[] All =
    [
        Completed,
        InProgress,
        OnHold,
        Pending
    ];

    private PrivateSigningStatus(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static PrivateSigningStatus Find(int id)
        => All.SingleOrDefault(status => status.Id == id);
}
