namespace Memorabilia.Domain.Constants
{
    public sealed class HelmetQualityType
    {
        public static readonly HelmetQualityType Authentic = new(1, "Authentic", "AUTH");
        public static readonly HelmetQualityType Replica = new(2, "Replica", "REP");

        public static readonly HelmetQualityType[] All =
        {
            Authentic,
            Replica
        };

        private HelmetQualityType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static HelmetQualityType Find(int id)
        {
            return All.SingleOrDefault(helmetQualityType => helmetQualityType.Id == id);
        }
    }
}
