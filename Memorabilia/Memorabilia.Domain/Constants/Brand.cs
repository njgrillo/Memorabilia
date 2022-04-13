using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Brand
    {
        public static readonly Brand Adidas = new(4, "Adidas", string.Empty);
        public static readonly Brand Beckett = new(14, "Beckett", string.Empty);
        public static readonly Brand Callaway = new(24, "Callaway", string.Empty);
        public static readonly Brand CCM = new(26, "CCM", string.Empty);
        public static readonly Brand Fender = new(22, "Fender", string.Empty);
        public static readonly Brand Fotoball = new(27, "Fotoball", string.Empty);
        public static readonly Brand Funko = new(19, "Funko Inc.", string.Empty);
        public static readonly Brand Hasbro = new(18, "Hasbro", string.Empty);
        public static readonly Brand Kenner = new(17, "Kenner", string.Empty);
        public static readonly Brand Majestic = new(5, "Majestic", string.Empty);
        public static readonly Brand Muslady = new(21, "Muslady", string.Empty);
        public static readonly Brand NewEra = new(25, "New Era", string.Empty);
        public static readonly Brand Nike = new(2, "Nike", string.Empty);
        public static readonly Brand None = new(8, "None", string.Empty);
        public static readonly Brand Other = new(7, "Other", string.Empty);
        public static readonly Brand Photofile = new(12, "Photofile", string.Empty);
        public static readonly Brand Rawlings = new(1, "Rawlings", string.Empty);
        public static readonly Brand Reach = new(28, "Reach", string.Empty);
        public static readonly Brand Reebok = new(3, "Reebok", "RBK");  
        public static readonly Brand Riddell = new(11, "Riddell", string.Empty);
        public static readonly Brand Salvino = new(20, "Salvino", string.Empty);
        public static readonly Brand Spalding = new(10, "Spalding", string.Empty);  
        public static readonly Brand Spinneybeck = new(9, "Spinneybeck", string.Empty);  
        public static readonly Brand SportsIllustrated = new(13, "Sports Illustrated", "SI");
        public static readonly Brand Titleist = new(23, "Titleist", string.Empty);
        public static readonly Brand Topps = new(15, "Topps", string.Empty);  
        public static readonly Brand UpperDeck = new(16, "Upper Deck", "UD");  
        public static readonly Brand Wilson = new(6, "Wilson", string.Empty);

        public static readonly Brand[] All =
        {
            Adidas,
            Beckett,
            Callaway,
            CCM,
            Fender,
            Fotoball,
            Funko,
            Hasbro,
            Kenner,
            Majestic,
            Muslady,
            NewEra,
            Nike,
            None,
            Other,
            Photofile,
            Rawlings,
            Reach,
            Reebok,
            Riddell,
            Salvino,
            Spalding,
            Spinneybeck,
            SportsIllustrated,
            Titleist,
            Topps,
            UpperDeck,
            Wilson
        };

        public static readonly Brand[] GameWorthlyBaseballBrand =
        {
            Rawlings,
            Reach,
            Spalding
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

        public static Brand Find(string name)
        {
            return All.SingleOrDefault(brand => brand.Name == name);
        }

        public static bool IsGameWorthlyBaseballBrand(int id)
        {
            return GameWorthlyBaseballBrand.Contains(Find(id));
        }

        public static bool IsGameWorthlyBaseballBrand(Brand brand)
        {
            return GameWorthlyBaseballBrand.Contains(brand);
        }
    }
}
