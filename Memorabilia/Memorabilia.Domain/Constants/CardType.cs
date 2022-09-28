namespace Memorabilia.Domain.Constants
{
    public sealed class CardType
    {
        public static readonly CardType Trading = new(1, "Trading Card", string.Empty);
        public static readonly CardType Playing = new(2, "Playing Card", string.Empty);

        public static readonly CardType[] All =
        {
            Trading,
            Playing
        };

        private CardType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static CardType Find(int id)
        {
            return All.SingleOrDefault(CardType => CardType.Id == id);
        }
    }
}
