using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Division
    {
        public static readonly Division AFCEast = new(1, "AFC East", string.Empty);
        public static readonly Division AFCNorth = new(2, "AFC North", string.Empty);
        public static readonly Division AFCSouth = new(3, "AFC South", string.Empty);
        public static readonly Division AFCWest = new(4, "AFC West", string.Empty);
        public static readonly Division NFCEast = new(6, "NFC East", string.Empty);
        public static readonly Division NFCNorth = new(5, "NFC North", string.Empty);
        public static readonly Division NFCSouth = new(7, "NFC South", string.Empty);
        public static readonly Division NFCWest = new(8, "NFC West", string.Empty);
        public static readonly Division Century = new(9, "NFL - Century Division", string.Empty);
        public static readonly Division WesternDivision = new(10, "NFL - Western Division", string.Empty);
        public static readonly Division Coastal = new(11, "NFL - Coastal Division", string.Empty);
        public static readonly Division AFCCentral = new(12, "AFC Central", string.Empty);
        public static readonly Division NFCCentral = new(13, "NFC Central", string.Empty);
        public static readonly Division EasternDivision = new(14, "NFL - Eastern Division", string.Empty);
        public static readonly Division CentralDivision = new(15, "NFL - Central Division", string.Empty);
        public static readonly Division AFLWest = new(16, "AFL West", string.Empty);
        public static readonly Division Capitol = new(17, "Capitol Division", string.Empty);
        public static readonly Division ALEast = new(18, "AL East", string.Empty);
        public static readonly Division ALCentral = new(19, "AL Central", string.Empty);
        public static readonly Division ALWest = new(20, "AL West", string.Empty);
        public static readonly Division NLEast = new(21, "NL East", string.Empty);
        public static readonly Division NLCentral = new(22, "NL Central", string.Empty);
        public static readonly Division NLWest = new(23, "NL West", string.Empty);

        public static readonly Division[] All =
        {
            AFCEast,
            AFCNorth,
            AFCSouth,
            AFCWest,
            NFCEast,
            NFCNorth,
            NFCSouth,
            NFCWest,
            Century,
            WesternDivision,
            Coastal,
            AFCCentral,
            NFCCentral,
            EasternDivision,
            CentralDivision,
            AFLWest,
            Capitol,
            ALEast,
            ALCentral,
            ALWest,
            NLEast,
            NLCentral,
            NLWest
        };

        public static readonly Division[] MajorLeagueBaseball =
        {
            ALEast,
            ALCentral,
            ALWest,
            NLEast,
            NLCentral,
            NLWest
        };

        public static readonly Division[] NationalFootballLeague =
        {
            AFCEast,
            AFCNorth,
            AFCSouth,
            AFCWest,
            NFCEast,
            NFCNorth,
            NFCSouth,
            NFCWest,
            AFCCentral,
            NFCCentral,
            AFLWest,
            Capitol,
            Century,
            Coastal,
            CentralDivision,
            EasternDivision,
            WesternDivision
        };

        private Division(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static Division Find(int id)
        {
            return All.SingleOrDefault(Division => Division.Id == id);
        }

        public static Division[] GetAll(SportLeagueLevel sportLeagueLevel)
        {
            if (sportLeagueLevel == SportLeagueLevel.MajorLeagueBaseball)
                return MajorLeagueBaseball;

            if (sportLeagueLevel == SportLeagueLevel.NationalFootballLeague)
                return NationalFootballLeague;

            return All;
        }
    }
}
