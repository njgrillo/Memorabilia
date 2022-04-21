using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class AccomplishmentType
    {
        
        public static readonly AccomplishmentType NoHitter = new(1, "No Hitter", string.Empty);
        public static readonly AccomplishmentType TripleCrown = new(2, "Triple Crown", string.Empty);    

        public static readonly AccomplishmentType[] All =
        {
            NoHitter,
            TripleCrown
        };

        private AccomplishmentType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static AccomplishmentType Find(int id)
        {
            return All.SingleOrDefault(accomplishmentType => accomplishmentType.Id == id);
        }
    }
}
