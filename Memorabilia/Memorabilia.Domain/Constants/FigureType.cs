using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class FigureType
    {
        public static readonly FigureType StartingLineup = new(1, "Starting Lineup", "SLU");
        public static readonly FigureType FunkoPop = new(2, "Funko Pop", string.Empty);

        public static readonly FigureType[] All =
        {
            StartingLineup,
            FunkoPop
        };

        private FigureType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static FigureType Find(int id)
        {
            return All.SingleOrDefault(FigureType => FigureType.Id == id);
        }
    }
}
