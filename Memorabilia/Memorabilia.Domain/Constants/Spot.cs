using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Spot
    {
        public static readonly Spot SweetSpot = new(1, "Sweet Spot", string.Empty);
        public static readonly Spot SidePanel = new(2, "Side Panel", string.Empty);
        public static readonly Spot OnCloth = new(3, "On Cloth", string.Empty);
        public static readonly Spot OnNumber = new(4, "On Number", string.Empty);

        public static readonly Spot[] All =
        {
            SweetSpot,
            SidePanel,
            OnCloth,
            OnNumber
        };

        private Spot(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static Spot Find(int id)
        {
            return All.SingleOrDefault(Spot => Spot.Id == id);
        }
    }
}
