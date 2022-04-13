using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class BammerType
    {
        public static readonly BammerType BabyBammer = new(1, "Baby Bammer", string.Empty);
        public static readonly BammerType Bammer = new(2, "Bammer", string.Empty);
        public static readonly BammerType BammBeano = new(3, "Bamm Beano", string.Empty);
        public static readonly BammerType BigBammer = new(4, "Big Bammer", string.Empty);
        public static readonly BammerType OpeningDay = new(5, "Opening Day Bammer", string.Empty);

        public static readonly BammerType[] All =
        {
            BabyBammer,
            Bammer,
            BammBeano,
            BigBammer,
            OpeningDay
        };

        private BammerType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static BammerType Find(int id)
        {
            return All.SingleOrDefault(bammerType => bammerType.Id == id);
        }
    }
}
