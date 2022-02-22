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
        public static readonly Division Century = new(9, "Century Division", string.Empty);
        public static readonly Division Western = new(10, "Western Division", string.Empty);
        public static readonly Division Coastal = new(11, "Coastal Division", string.Empty);
        public static readonly Division AFCCentral = new(12, "AFC Central", string.Empty);
        public static readonly Division NFCCentral = new(13, "NFC Central", string.Empty);
        public static readonly Division EasternDivision = new(14, "Eastern Division", string.Empty);
        public static readonly Division CentralDivision = new(15, "Central Division", string.Empty);
        public static readonly Division AFLWest = new(16, "AFL West", string.Empty);
        public static readonly Division Capitol = new(17, "Capitol Division", string.Empty);

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
            Western,
            Coastal,
            AFCCentral,
            NFCCentral,
            EasternDivision,
            CentralDivision,
            AFLWest,
            Capitol
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
    }
}
