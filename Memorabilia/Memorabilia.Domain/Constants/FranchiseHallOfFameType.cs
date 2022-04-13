using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class FranchiseHallOfFameType
    {
        public static readonly FranchiseHallOfFameType BravesHallOfFame = new(1, "Braves Hall of Fame", string.Empty);
        public static readonly FranchiseHallOfFameType MilwaukeeBrewersWallOfHonor = new(2, "Milwaukee Brewers Wall of Honor", string.Empty);

        public static readonly FranchiseHallOfFameType[] All =
        {
            BravesHallOfFame,
            MilwaukeeBrewersWallOfHonor
        };

        private FranchiseHallOfFameType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static FranchiseHallOfFameType Find(int id)
        {
            return All.SingleOrDefault(franchiseHallOfFameType => franchiseHallOfFameType.Id == id);
        }
    }
}
