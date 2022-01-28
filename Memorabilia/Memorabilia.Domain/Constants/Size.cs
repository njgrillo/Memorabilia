using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Size
    {       
        public static readonly Size Full = new(2, "Full", string.Empty);
        public static readonly Size Large = new(3, "Large", string.Empty);
        public static readonly Size Mini = new(1, "Mini", string.Empty);
        public static readonly Size Oversized = new(6, "Oversized", string.Empty);
        public static readonly Size Small = new(4, "Small", string.Empty);
        public static readonly Size Standard = new(5, "Standard", string.Empty);        

        public static readonly Size[] All =
        {
            Full,
            Large,
            Mini,
            Oversized,
            Small,
            Standard
        };

        private Size(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static Size Find(int id)
        {
            return All.SingleOrDefault(size => size.Id == id);
        }
    }
}
