using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Sport
    {
        public static readonly Sport Baseball = new(1, "Baseball", string.Empty);
        public static readonly Sport Basketball = new(2, "Basketball", string.Empty);
        public static readonly Sport Football = new(3, "Football", string.Empty);
        public static readonly Sport Hockey = new(4, "Hockey", string.Empty);
        public static readonly Sport Soccer= new(5, "Soccer", "Futbol");

        public static readonly Sport[] All =
        {
            Baseball,
            Basketball,
            Football,
            Hockey,
            Soccer
        };

        private Sport(int id, string name, string alternateName)
        {
            Id = id;
            Name = name;
            AlternateName = alternateName;
        }

        public string AlternateName { get; }

        public int Id { get; }

        public string Name { get; }

        public static Sport Find(int id)
        {
            return All.SingleOrDefault(Sport => Sport.Id == id);
        }
    }
}
