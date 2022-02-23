using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Brand
    {
        public static readonly Brand Adidas = new(4, "Adidas", string.Empty);
        public static readonly Brand Beckett = new(14, "Beckett", string.Empty);
        public static readonly Brand Majestic = new(5, "Majestic", string.Empty);
        public static readonly Brand Nike = new(2, "Nike", string.Empty);
        public static readonly Brand None = new(8, "None", string.Empty);
        public static readonly Brand Other = new(7, "Other", string.Empty);
        public static readonly Brand Photofile = new(12, "Photofile", string.Empty);
        public static readonly Brand Rawlings = new(1, "Rawlings", string.Empty);       
        public static readonly Brand Reebok = new(3, "Reebok", "RBK");  
        public static readonly Brand Riddell = new(11, "Riddell", string.Empty);  
        public static readonly Brand Spalding = new(10, "Spalding", string.Empty);  
        public static readonly Brand Spinneybeck = new(9, "Spinneybeck", string.Empty);  
        public static readonly Brand SportsIllustrated = new(13, "Sports Illustrated", "SI");  
        public static readonly Brand Wilson = new(6, "Wilson", string.Empty);

        public static readonly Brand[] All =
        {
            Adidas,
            Beckett,
            Majestic,
            Nike,
            None,
            Other,
            Photofile,
            Rawlings,
            Reebok,
            Riddell,
            Spalding,
            Spinneybeck,
            SportsIllustrated,
            Wilson
        };

        private Brand(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static Brand Find(int id)
        {
            return All.SingleOrDefault(brand => brand.Id == id);
        }
    }
}
