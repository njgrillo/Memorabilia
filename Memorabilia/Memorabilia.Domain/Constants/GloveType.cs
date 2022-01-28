using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class GloveType
    {
        public static readonly GloveType Baseball = new(1, "Baseball Glove", string.Empty);
        public static readonly GloveType Batting = new(2, "Batting Glove", string.Empty);
        public static readonly GloveType Football = new(3, "Football Glove", string.Empty);
        public static readonly GloveType Hockey = new(4, "Hockey Glove", string.Empty);
        public static readonly GloveType Boxing = new(5, "Boxing Glove", string.Empty);
        public static readonly GloveType MMA = new(5, "MMA Glove", "MMA");

        public static readonly GloveType[] All =
        {
            Baseball,
            Batting,
            Football,
            Hockey,
            Boxing,
            MMA
        };

        private GloveType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static GloveType Find(int id)
        {
            return All.SingleOrDefault(GloveType => GloveType.Id == id);
        }
    }
}
