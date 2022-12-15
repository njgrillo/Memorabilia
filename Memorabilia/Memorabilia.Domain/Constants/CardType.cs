namespace Memorabilia.Domain.Constants;

public sealed class CardType : DomainItemConstant
{
    public static readonly CardType Trading = new(1, "Trading Card");
    public static readonly CardType Playing = new(2, "Playing Card");

    public static readonly CardType[] All =
    {
        Trading,
        Playing
    };

    private CardType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static CardType Find(int id)
    {
        return All.SingleOrDefault(CardType => CardType.Id == id);
    }
}
