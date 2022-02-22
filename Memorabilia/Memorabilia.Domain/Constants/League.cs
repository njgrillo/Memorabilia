using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class League
    {
        public static readonly League AmericanLeague = new(1, "American League", "AL");
        public static readonly League NationalLeague = new(2, "National League", "NL");
        public static readonly League NationalFootballLeague = new(3, "National Football League", "NFL");
        public static readonly League AmericanFootballLeague = new(4, "American Football League", "AFL");

        public static readonly League[] All =
        {
            AmericanLeague,
            AmericanFootballLeague,
            NationalFootballLeague,
            NationalLeague
        };

        private League(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static League Find(int id)
        {
            return All.SingleOrDefault(league => league.Id == id);
        }
    }
}
