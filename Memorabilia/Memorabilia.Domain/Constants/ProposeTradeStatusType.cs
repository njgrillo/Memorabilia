namespace Memorabilia.Domain.Constants;

public sealed class ProposeTradeStatusType : DomainItemConstant
{
    public static readonly ProposeTradeStatusType Accepted = new(1, "Accepted");
    public static readonly ProposeTradeStatusType Canceled = new(6, "Canceled");
    public static readonly ProposeTradeStatusType Countered = new(2, "Countered");
    public static readonly ProposeTradeStatusType Expired = new(3, "Expired");
    public static readonly ProposeTradeStatusType Pending = new(4, "Pending");
    public static readonly ProposeTradeStatusType Rejected = new(5, "Rejected");

    public static readonly ProposeTradeStatusType[] All =
    {
        Accepted,
        Canceled,
        Countered,
        Expired,
        Pending,
        Rejected
    };

    public static readonly ProposeTradeStatusType[] Completed =
    {
        Accepted,
        Canceled,
        Countered,
        Expired,
        Rejected
    };

    public static readonly ProposeTradeStatusType[] Open =
    {
        Pending
    };

    private ProposeTradeStatusType(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static ProposeTradeStatusType Find(int id)
        => All.SingleOrDefault(proposeTradeStatusType => proposeTradeStatusType.Id == id);

    public static bool IsCompleted(int proposeTradeStatusTypeId)
        => Completed.Contains(Find(proposeTradeStatusTypeId));

    public static bool IsOpen(int proposeTradeStatusTypeId)
        => Open.Contains(Find(proposeTradeStatusTypeId));
}
