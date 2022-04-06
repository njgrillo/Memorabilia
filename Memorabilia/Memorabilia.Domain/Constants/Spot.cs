using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Spot
    {
        public static readonly Spot BackCloth = new(24, "Back - On Cloth", string.Empty);
        public static readonly Spot BackCover = new(6, "Back Cover", string.Empty);
        public static readonly Spot BackNumber = new(21, "Back - On Number", string.Empty);
        public static readonly Spot BottomLeft = new(17, "Bottom - Facemask Facing Left", string.Empty);
        public static readonly Spot BottomRight = new(16, "Bottom - Facemask Facing Right", string.Empty);
        public static readonly Spot Crown = new(20, "Crown", string.Empty);
        public static readonly Spot FrontCloth = new(22, "Front - On Cloth", string.Empty);
        public static readonly Spot FrontCover = new(5, "Front Cover", string.Empty);
        public static readonly Spot FrontNumber = new(23, "Front - On Number", string.Empty);
        public static readonly Spot Inside = new(7, "Inside", string.Empty);
        public static readonly Spot MiddleLeft = new(19, "Middle - Facemask Facing Left", string.Empty);
        public static readonly Spot MiddleRight = new(18, "Middle - Facemask Facing Right", string.Empty);
        public static readonly Spot OnBack = new(10, "On Back", string.Empty);
        public static readonly Spot OnBookplate = new(8, "On Bookplate", string.Empty);
        public static readonly Spot OnCardboard = new(12, "On Cardboard", string.Empty);
        public static readonly Spot OnCloth = new(3, "On Cloth", string.Empty);
        public static readonly Spot OnFront = new(9, "On Front", string.Empty);        
        public static readonly Spot OnNumber = new(4, "On Number", string.Empty);        
        public static readonly Spot OnPlastic = new(11, "On Plastic", string.Empty);        
        public static readonly Spot SidePanel = new(2, "Side Panel", string.Empty);
        public static readonly Spot SweetSpot = new(1, "Sweet Spot", string.Empty);
        public static readonly Spot TopLeft = new(15, "Top - Facemask Facing Left", string.Empty);
        public static readonly Spot TopRight = new(14, "Top - Facemask Facing Right", string.Empty);
        public static readonly Spot UnderLogo = new(13, "Under Logo", string.Empty);

        public static readonly Spot[] All =
        {
            BackCloth,
            BackCover,
            BackNumber,
            BottomLeft,
            BottomRight,
            Crown,
            FrontCloth,
            FrontCover,
            FrontNumber,
            Inside,
            MiddleLeft,
            MiddleRight,
            OnBack,
            OnBookplate,
            OnCardboard,
            OnCloth,
            OnFront,
            OnNumber, 
            OnPlastic,
            SidePanel,
            SweetSpot,
            TopLeft,
            TopRight,
            UnderLogo
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
            return All.SingleOrDefault(spot => spot.Id == id);
        }

        public static Spot Find(string name)
        {
            return All.SingleOrDefault(spot => spot.Name == name);
        }
    }
}
