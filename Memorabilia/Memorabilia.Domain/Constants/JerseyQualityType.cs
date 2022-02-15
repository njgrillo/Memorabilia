using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class JerseyQualityType
    {
        public static readonly JerseyQualityType Authentic = new(1, "Authentic", string.Empty);
        public static readonly JerseyQualityType Replica = new(2, "Replica", string.Empty);
        public static readonly JerseyQualityType China = new(3, "China", string.Empty);
        public static readonly JerseyQualityType Custom = new(4, "Custom", string.Empty);
        public static readonly JerseyQualityType Other = new(5, "Other", string.Empty);
        public static readonly JerseyQualityType Unknown = new(6, "Unknown", string.Empty);

        public static readonly JerseyQualityType[] All =
        {
            Authentic,
            China,
            Custom,
            Other,
            Replica,            
            Unknown
        };

        private JerseyQualityType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static JerseyQualityType Find(int id)
        {
            return All.SingleOrDefault(jerseyQualityType => jerseyQualityType.Id == id);
        }
    }
}
