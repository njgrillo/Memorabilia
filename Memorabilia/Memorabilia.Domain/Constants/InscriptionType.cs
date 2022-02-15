using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class InscriptionType
    {
        public static readonly InscriptionType HallOfFame = new(1, "Hall of Fame", "HOF");
        public static readonly InscriptionType MostValuablePlayer = new(2, "Most Valuable Player", "MVP");
        public static readonly InscriptionType Number = new(3, "Number", string.Empty);
        public static readonly InscriptionType RookieOfTheYear = new(4, "Rookie of the Year", "ROY");
        public static readonly InscriptionType CyYoung = new(5, "Cy Young", "CY");
        public static readonly InscriptionType BibleVerse = new(6, "Bible Verse", string.Empty);

        public static readonly InscriptionType[] All =
        {
            BibleVerse,
            CyYoung,
            HallOfFame,
            MostValuablePlayer,
            Number,
            RookieOfTheYear  
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
