using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Conference
    {
        public static readonly Conference AmericanFootballConference = new(1, "American Football Conference", "AFC");
        public static readonly Conference NationalFootballConference = new(2, "National Football Conference", "NFC");
        public static readonly Conference EasternConference = new(3, "Eastern Conference", "EAST");
        public static readonly Conference WesternConference = new(4, "Western Conference", "WEST");
        public static readonly Conference AmericanConference = new(5, "American Conference", string.Empty);
        public static readonly Conference NFLEasternConference = new(6, "NFL - Eastern Conference", string.Empty);
        public static readonly Conference NFLWesternConference = new(7, "NFL - Western Conference", string.Empty);
        public static readonly Conference NFLNationalConference = new(8, "NFL - National Conference", string.Empty);
        public static readonly Conference AllAmericanFootballConference = new(9, "All-America Football Conference", string.Empty);

        public static readonly Conference[] All =
        {
            AmericanConference,
            AmericanFootballConference,
            NationalFootballConference,
            NFLEasternConference,
            NFLNationalConference,
            NFLWesternConference,
            EasternConference,
            WesternConference,
            AllAmericanFootballConference
        };

        private Conference(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static Conference Find(int id)
        {
            return All.SingleOrDefault(conference => conference.Id == id);
        }
    }
}
