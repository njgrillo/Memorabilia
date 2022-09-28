namespace Memorabilia.Domain.Constants
{
    public sealed class Orientation
    {
        public static readonly Orientation Portrait = new(1, "Portrait", string.Empty);
        public static readonly Orientation Landscape = new(2, "Landscape", string.Empty);

        public static readonly Orientation[] All =
        {
            Portrait,
            Landscape
        };

        private Orientation(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static Orientation Find(int id)
        {
            return All.SingleOrDefault(orientation => orientation.Id == id);
        }
    }
}
