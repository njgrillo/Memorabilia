namespace Memorabilia.Domain.Constants
{
    public sealed class JerseyType
    {
        public static readonly JerseyType Stitched = new(1, "Stitched", string.Empty);
        public static readonly JerseyType ScreenPrint = new(2, "Screen Printed", string.Empty);
        public static readonly JerseyType Other = new(3, "Other", string.Empty);
        public static readonly JerseyType None = new(4, "None", string.Empty);
        public static readonly JerseyType Unknown = new(5, "Unknown", string.Empty);

        public static readonly JerseyType[] All =
        {
            Stitched,
            ScreenPrint,
            Other,
            None,
            Unknown
        };

        private JerseyType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static JerseyType Find(int id)
        {
            return All.SingleOrDefault(jerseyType => jerseyType.Id == id);
        }
    }
}
