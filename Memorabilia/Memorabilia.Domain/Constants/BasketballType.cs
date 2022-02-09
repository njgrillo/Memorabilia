using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class BasketballType
    {
        public static readonly BasketballType Official = new(1, "Official", string.Empty);
        public static readonly BasketballType Finals = new(2, "Finals", string.Empty);
        public static readonly BasketballType Commemorative = new(3, "Commemorative", string.Empty);
        public static readonly BasketballType Other = new(4, "Other", string.Empty);

        public static readonly BasketballType[] All =
        {
            Official,
            Finals,
            Commemorative,
            Other
        };

        private BasketballType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static BasketballType Find(int id)
        {
            return All.SingleOrDefault(basketballType => basketballType.Id == id);
        }
    }
}
