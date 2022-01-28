using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Color
    {
        public static readonly Color Blue = new(1, "Blue", string.Empty);
        public static readonly Color Black = new(2, "Black", string.Empty);
        public static readonly Color Silver = new(3, "Silver", string.Empty);
        public static readonly Color Gold = new(4, "Gold", string.Empty);
        public static readonly Color Red = new(5, "Red", string.Empty);
        public static readonly Color Orange = new(6, "Orange", string.Empty);
        public static readonly Color Other = new(7, "Other", string.Empty);

        public static readonly Color[] All =
        {
            Blue,
            Black,
            Silver,
            Gold,
            Red,
            Orange,
            Other
        };

        private Color(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static Color Find(int id)
        {
            return All.SingleOrDefault(Color => Color.Id == id);
        }
    }
}
