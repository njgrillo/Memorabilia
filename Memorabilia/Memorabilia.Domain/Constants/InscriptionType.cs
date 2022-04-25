using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class InscriptionType
    {
        public static readonly InscriptionType Accomplishment = new(10, "Accomplishment", string.Empty);
        public static readonly InscriptionType Award = new(11, "Award", string.Empty);
        public static readonly InscriptionType BibleVerse = new(6, "Bible Verse", string.Empty);
        public static readonly InscriptionType Championship = new(13, "Championship", string.Empty);
        public static readonly InscriptionType CyYoung = new(5, "Cy Young", "CY");
        public static readonly InscriptionType Draft = new(15, "Draft", string.Empty);
        public static readonly InscriptionType Greeting = new(8, "Greeting", string.Empty);
        public static readonly InscriptionType HallOfFame = new(1, "Hall of Fame", "HOF");
        public static readonly InscriptionType MostValuablePlayer = new(2, "Most Valuable Player", "MVP");
        public static readonly InscriptionType Nickname = new(12, "Nickname", string.Empty);
        public static readonly InscriptionType Number = new(3, "Number", string.Empty);
        public static readonly InscriptionType RookieOfTheYear = new(4, "Rookie of the Year", "ROY");
        public static readonly InscriptionType Statistic = new(9, "Statistic", "STAT");
        public static readonly InscriptionType Team = new(14, "Team", string.Empty);
        public static readonly InscriptionType WorldSeriesMVP = new(7, "World Series MVP", "WS MVP");                

        public static readonly InscriptionType[] All =
        {
            Accomplishment,
            Award,
            BibleVerse,
            Championship,
            CyYoung,
            Draft,
            Greeting,
            HallOfFame,
            MostValuablePlayer,
            Nickname,
            Number,
            RookieOfTheYear,
            Statistic,
            Team,
            WorldSeriesMVP
        };

        private InscriptionType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static InscriptionType Find(int id)
        {
            return All.SingleOrDefault(inscriptionType => inscriptionType.Id == id);
        }
    }
}
