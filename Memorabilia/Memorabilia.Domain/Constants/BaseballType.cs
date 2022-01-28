using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class BaseballType
    {
        public static readonly BaseballType AllStar = new(2, "All Star", string.Empty);
        public static readonly BaseballType Black = new(1, "Black Baseball", "ROMLBBG");   
        public static readonly BaseballType Official = new(4, "Offical Major League Baseball", "ROMLB");
        public static readonly BaseballType Spinneybeck = new(5, "Spinneybeck", string.Empty);
        public static readonly BaseballType WorldSeries = new(3, "World Series", string.Empty);

        public static readonly BaseballType[] All =
        {
            AllStar,
            Black,  
            Official,
            Spinneybeck,
            WorldSeries
        };

        private BaseballType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static BaseballType Find(int id)
        {
            return All.SingleOrDefault(BaseballType => BaseballType.Id == id);
        }
    }
}
