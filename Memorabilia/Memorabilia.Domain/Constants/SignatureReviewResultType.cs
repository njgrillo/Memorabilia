namespace Memorabilia.Domain.Constants;

public sealed class SignatureReviewResultType : DomainItemConstant
{
    public static readonly SignatureReviewResultType LikelyAuthentic = new(1, "Likely Authentic");
    public static readonly SignatureReviewResultType UnlikelyAuthentic = new(2, "Unlikely Authentic");

    public static readonly SignatureReviewResultType[] All =
    {
        LikelyAuthentic,
        UnlikelyAuthentic
    };

    private SignatureReviewResultType(int id, string name)
        : base(id, name) { }

    public static SignatureReviewResultType Find(int id)
        => All.SingleOrDefault(signatureReviewResultType => signatureReviewResultType.Id == id);
}
