using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class HelmetType
    {
        public static readonly HelmetType F7 = new(5, "F7", string.Empty);
        public static readonly HelmetType Flex = new(1, "Flex", string.Empty);
        public static readonly HelmetType Hydro = new(2, "Hydro", string.Empty);
        public static readonly HelmetType Other = new(6, "Other", string.Empty);
        public static readonly HelmetType Revolution = new(4, "Revolution", string.Empty);
        public static readonly HelmetType Speed = new(3, "Speed", string.Empty);        

        public static readonly HelmetType[] All =
        {
            F7,
            Flex,
            Hydro,
            Other,
            Revolution,
            Speed            
        };

        public static readonly HelmetType[] GameWorthly =
        {
            F7,
            Flex,
            Other,
            Revolution,
            Speed
        };

        private HelmetType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static HelmetType Find(int id)
        {
            return All.SingleOrDefault(helmetType => helmetType.Id == id);
        }

        public static HelmetType[] GetAll(GameStyleType gameStyleType)
        {
            if (gameStyleType == null || gameStyleType == GameStyleType.None)
                return All;

            return GameWorthly;
        }

        public static bool IsGameWorthly(HelmetType helmetType)
        {
            return GameWorthly.Contains(helmetType);
        }
    }
}
