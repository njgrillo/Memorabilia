namespace Memorabilia.Domain.Constants;

public sealed class UserMessageStatus : DomainItemConstant
{
    public static readonly UserMessageStatus New = new(1, "New");
    public static readonly UserMessageStatus Read = new(2, "Read");
    public static readonly UserMessageStatus Deleted = new(3, "Deleted");

    public static readonly UserMessageStatus[] All =
    {        
        New,
        Read,
        Deleted
    };

    private UserMessageStatus(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static UserMessageStatus Find(int id)
        => All.SingleOrDefault(userMessageStatus => userMessageStatus.Id == id);
}
