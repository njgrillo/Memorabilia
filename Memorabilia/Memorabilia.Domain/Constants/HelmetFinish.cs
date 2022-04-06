using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class HelmetFinish
    {
        public static readonly HelmetFinish Blaze = new(6, "Blaze", string.Empty);
        public static readonly HelmetFinish Bronze = new(5, "Bronze", string.Empty);
        public static readonly HelmetFinish Chrome = new(2, "Chrome", string.Empty);
        public static readonly HelmetFinish Copper = new(14, "Copper", string.Empty);
        public static readonly HelmetFinish Custom = new(9, "Custom", string.Empty);
        public static readonly HelmetFinish Drip = new(10, "Drip", string.Empty);
        public static readonly HelmetFinish Flash = new(7, "Flash", string.Empty);
        public static readonly HelmetFinish Hydro = new(13, "Hydro", string.Empty);
        public static readonly HelmetFinish Ice = new(8, "Ice", string.Empty);
        public static readonly HelmetFinish Other = new(12, "Other", string.Empty);
        public static readonly HelmetFinish Pewter = new(1, "Pewter", string.Empty);
        public static readonly HelmetFinish Ripped = new(11, "Ripped", string.Empty);
        public static readonly HelmetFinish SterlingSilver = new(4, "Sterling Silver", string.Empty);
        public static readonly HelmetFinish TwentyFourKaratGoldPlated = new(3, "24k Gold Plated", string.Empty);

        public static readonly HelmetFinish[] All =
        {
            Blaze,
            Bronze,
            Chrome,
            Copper,
            Custom,
            Drip,
            Flash,
            Hydro,
            Ice,
            Other,
            Pewter,
            Ripped,
            SterlingSilver,
            TwentyFourKaratGoldPlated
        };

        private HelmetFinish(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static HelmetFinish Find(int id)
        {
            return All.SingleOrDefault(helmetFinish => helmetFinish.Id == id);
        }
    }
}
