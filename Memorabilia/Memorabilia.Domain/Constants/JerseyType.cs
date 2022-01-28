using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class JerseyType
    {
        public static readonly JerseyType Home = new(1, "Home", string.Empty);
        public static readonly JerseyType Away = new(2, "Away", string.Empty);
        public static readonly JerseyType Alternate = new(3, "Alternate", string.Empty);
        public static readonly JerseyType WorldSeries = new(4, "World Series", string.Empty);
        public static readonly JerseyType AllStar = new(5, "All Star", string.Empty);
        public static readonly JerseyType ProBowl = new(6, "Pro Bowl", string.Empty);
        public static readonly JerseyType Finals = new(7, "Finals", string.Empty);
        public static readonly JerseyType Throwback = new(8, "Throwback", string.Empty);

        public static readonly JerseyType[] All =
        {
            Home,
            Away,
            Alternate,
            WorldSeries,
            AllStar,
            ProBowl,
            Finals,
            Throwback
        };

        private JerseyType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static JerseyType Find(int id)
        {
            return All.SingleOrDefault(JerseyType => JerseyType.Id == id);
        }
    }
}
