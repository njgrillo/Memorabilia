using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class HelmetType
    {
        public static readonly HelmetType Pewter = new(1, "Pewter", string.Empty);
        public static readonly HelmetType Chrome = new(2, "Chrome", string.Empty);
        public static readonly HelmetType Throwback = new(3, "Throwback", string.Empty);
        public static readonly HelmetType TwentyFourKaratGoldPlated = new(4, "24k Gold Plated", string.Empty);
        public static readonly HelmetType SterlingSilver = new(5, "Sterling Silver", string.Empty);
        public static readonly HelmetType Bronze = new(6, "Bronze", string.Empty);
        public static readonly HelmetType Revolution = new(7, "Revolution", string.Empty);
        public static readonly HelmetType Speed = new(8, "Speed", string.Empty);
        public static readonly HelmetType Blaze = new(9, "Blaze", string.Empty);
        public static readonly HelmetType Ice = new(10, "Ice", string.Empty);
        public static readonly HelmetType Flash = new(11, "Flash", string.Empty);

        public static readonly HelmetType[] All =
        {
            Blaze,
            Bronze,
            Chrome,
            Flash,
            Ice,
            Pewter,
            Revolution,
            Throwback,
            TwentyFourKaratGoldPlated,
            Speed,
            SterlingSilver
        };

        public static readonly HelmetType[] FullSizeHelmetTypes =
        {
            Blaze,
            Chrome,
            Flash,
            Ice,
            Pewter,
            Revolution,
            Throwback,
            TwentyFourKaratGoldPlated,
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
    }
}
