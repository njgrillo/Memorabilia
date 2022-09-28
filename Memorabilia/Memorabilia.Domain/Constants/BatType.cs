namespace Memorabilia.Domain.Constants
{
    public sealed class BatType
    {
        public static readonly BatType BigStick = new(1, "Big Stick", string.Empty);
        public static readonly BatType GameModel = new(2, "Game Model", string.Empty);
        public static readonly BatType Commemorative = new(3, "Commemorative", string.Empty);
        public static readonly BatType None = new(4, "None", string.Empty);
        public static readonly BatType Other = new(5, "Other", string.Empty);

        public static readonly BatType[] All =
        {
            BigStick,
            Commemorative,
            GameModel,            
            None,
            Other
        };

        private BatType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static BatType Find(int id)
        {
            return All.SingleOrDefault(batType => batType.Id == id);
        }
    }
}
