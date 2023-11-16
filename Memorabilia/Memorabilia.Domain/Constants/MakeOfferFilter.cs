namespace Memorabilia.Domain.Constants;

public sealed class MakeOfferFilter : Filter<MakeOfferFilter>
{
    public static readonly MakeOfferFilter None = new("None");
    public static readonly MakeOfferFilter MakeOffer = new("Is Make Offer");
    public static readonly MakeOfferFilter NotMakeOffer = new("Is Not Make Offer");

    private MakeOfferFilter(string name)
        : base(name) { }

    public static readonly MakeOfferFilter[] All =
    [
        None,
        MakeOffer,
        NotMakeOffer
    ];

    public static readonly MakeOfferFilter[] FilterItems =
    [
        MakeOffer,
        NotMakeOffer
    ];
}
