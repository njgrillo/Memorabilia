using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class College
    {
        public static readonly College CentralFlorida = new(1, "Central Florida", "UCF");

        public static readonly College[] All =
        {
            CentralFlorida
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
