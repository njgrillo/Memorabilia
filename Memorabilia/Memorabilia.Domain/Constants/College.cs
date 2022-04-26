using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class College
    {
        public static readonly College ArizonaState = new(12, "Arizona State", "ASU");
        public static readonly College CentralFlorida = new(1, "Central Florida", "UCF");
        public static readonly College EastCentralCommunityCollege = new (6, "East Central Community College", "ECCC");
        public static readonly College Florida = new(5, "Florida", "UF");
        public static readonly College Hartford = new(7, "Hartford", "UHart");
        public static readonly College LouisianaState = new(8, "Louisiana State", "LSU");
        public static readonly College Marshall = new(11, "Marshall", string.Empty);
        public static readonly College Miami = new(14, "Miami", "UM");
        public static readonly College MiamiDade = new(18, "Miami Dade", "MDC");
        public static readonly College Mississippi = new(4, "Mississippi", "Ole Miss");
        public static readonly College MississippiState = new(21, "Mississippi State", "MS");
        public static readonly College NavarroCollege = new(25, "Navarro College", string.Empty);
        public static readonly College OregonState = new(23, "Oregon State", "OSU");
        public static readonly College Rice = new(9, "Rice", string.Empty);
        public static readonly College SetonHall = new(10, "Seton Hall", string.Empty);
        public static readonly College SlipperyRock = new(2, "Slippery Rock", "SRU");
        public static readonly College SouthCarolina = new(13, "South Carolina", "SC");
        public static readonly College Southern = new(15, "Southern", "SU");
        public static readonly College SouthernMississippi = new(3, "Southern Mississippi", "Southern Miss");
        public static readonly College Stetson = new(26, "Stetson", string.Empty);
        public static readonly College Texas = new(22, "Texas", "UT");
        public static readonly College TexasChristian = new(19, "Texas Christian", "TCU");
        public static readonly College VirginiaState = new(16, "Virginia State", "VSU");
        public static readonly College WakeForest = new(24, "Wake Forest", string.Empty);
        public static readonly College WichitaState = new(20, "Wichita State", "WSU");
        public static readonly College Xavier = new(17, "Xavier", string.Empty);

        public static readonly College[] All =
        {
            ArizonaState,
            CentralFlorida,
            EastCentralCommunityCollege,
            Florida,
            Hartford,
            LouisianaState,
            Marshall,
            Miami,
            MiamiDade,
            Mississippi,
            MississippiState,
            NavarroCollege,
            OregonState,
            Rice,
            SetonHall,
            SlipperyRock,
            SouthCarolina,
            Southern,
            SouthernMississippi,
            Stetson,
            Texas,
            TexasChristian,
            VirginiaState,
            WakeForest,
            WichitaState,
            Xavier
        };

        private College(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static College Find(int id)
        {
            return All.SingleOrDefault(college => college.Id == id);
        }
    }
}
