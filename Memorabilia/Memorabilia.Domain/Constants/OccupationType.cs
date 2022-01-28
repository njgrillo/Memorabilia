using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class OccupationType
    {
        public static readonly OccupationType Athlete = new(1, "Athlete", string.Empty);
        public static readonly OccupationType Actor = new(2, "Actor", string.Empty);
        public static readonly OccupationType Actress = new(3, "Actress", string.Empty);
        public static readonly OccupationType Celebrity = new(4, "Celebrity", string.Empty);
        public static readonly OccupationType Broadcaster = new(5, "Broadcaster", string.Empty);
        public static readonly OccupationType Comedian = new(6, "Comedian", string.Empty);

        public static readonly OccupationType[] All =
        {
            Athlete,
            Actor,
            Actress,
            Celebrity,
            Broadcaster,
            Comedian
        };

        private OccupationType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static OccupationType Find(int id)
        {
            return All.SingleOrDefault(OccupationType => OccupationType.Id == id);
        }
    }
}
