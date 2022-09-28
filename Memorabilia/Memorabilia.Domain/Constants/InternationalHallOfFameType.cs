namespace Memorabilia.Domain.Constants
{
    public sealed class InternationalHallOfFameType
    {
        public static readonly InternationalHallOfFameType CanadianHallOfFame = new(1, "Canadian Hall of Fame");
        public static readonly InternationalHallOfFameType CaribbeanHallOfFame = new(2, "Caribbean Hall of Fame");
        public static readonly InternationalHallOfFameType JapaneseHallOfFame = new(3, "Japanese Hall of Fame");
        public static readonly InternationalHallOfFameType MexicanHallOfFame = new(4, "Mexican Hall of Fame");
        
        public static readonly InternationalHallOfFameType[] All =
        {
            CanadianHallOfFame,
            CaribbeanHallOfFame,
            JapaneseHallOfFame,
            MexicanHallOfFame
        };

        private InternationalHallOfFameType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static InternationalHallOfFameType Find(int id)
        {
            return All.SingleOrDefault(internationalHallOfFameType => internationalHallOfFameType.Id == id);
        }
    }
}
