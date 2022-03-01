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
        public static readonly Color Ash = new(8, "Ash", string.Empty);
        public static readonly Color Blonde = new(9, "Blonde", string.Empty);

        public static readonly Color[] All =
        {
            Ash,
            Black,
            Blonde,
            Blue,
            Gold,
            Orange,
            Other,
            Red,
            Silver  
        };

        public static readonly Color[] Autograph =
        {
            Black,
            Blue,
            Gold,
            Orange,
            Other,
            Red,
            Silver
        };

        public static readonly Color[] Bat =
        {
            Ash,
            Black,
            Blonde,
            Blue,
            Gold,
            Other,
            Red
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
            return All.SingleOrDefault(color => color.Id == id);
        }

        public static Color[] GetAll(ItemType itemType)
        {
            if (itemType == null)
                return All;

            if (itemType == ItemType.Bat)
                return Bat;

            return All;
        }
    }
}
