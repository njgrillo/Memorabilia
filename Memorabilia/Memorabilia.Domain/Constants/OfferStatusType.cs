namespace Memorabilia.Domain.Constants;

public sealed class OfferStatusType : DomainItemConstant
{
    public static readonly OfferStatusType Accepted = new(1, "Accepted");
    public static readonly OfferStatusType Canceled = new(6, "Canceled");
    public static readonly OfferStatusType Countered = new(2, "Countered");
    public static readonly OfferStatusType Expired = new(3, "Expired");
    public static readonly OfferStatusType Pending = new(4, "Pending");
    public static readonly OfferStatusType Rejected = new(5, "Rejected");

    public static readonly OfferStatusType[] All =
    {
        Accepted,
        Canceled,
        Countered,
        Expired,
        Pending,
        Rejected
    };

    public static readonly OfferStatusType[] Completed =
    {
        Accepted,
        Canceled,
        Countered,
        Expired,
        Rejected
    };

    public static readonly OfferStatusType[] Open =
    {
        Pending
    };

    private OfferStatusType(int id, string name, string abbreviation = null)
        : base(id, name, abbreviation) { }

    public static OfferStatusType Find(int id)
        => All.SingleOrDefault(offerStatusType => offerStatusType.Id == id);

    public static bool IsCompleted(int offerStatusTypeId)
        => Completed.Contains(Find(offerStatusTypeId));

    public static bool IsOpen(int offerStatusTypeId)
        => Open.Contains(Find(offerStatusTypeId));
}
