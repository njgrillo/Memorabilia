using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class JerseyLevelType
    {
        public static readonly JerseyLevelType College = new(1, "College", string.Empty);
        public static readonly JerseyLevelType HighSchool = new(2, "High School", string.Empty);
        public static readonly JerseyLevelType Professional = new(3, "Professional", string.Empty);

        public static readonly JerseyLevelType[] All =
        {
            College,
            HighSchool,
            Professional
        };

        private JerseyLevelType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static JerseyLevelType Find(int id)
        {
            return All.SingleOrDefault(jerseyLevelType => jerseyLevelType.Id == id);
        }
    }
}
