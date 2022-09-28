namespace Memorabilia.Domain.Constants
{
    public sealed class WritingInstrument
    {
        public static readonly WritingInstrument BallpointPen = new(1, "Ballpoint Pen", string.Empty);
        public static readonly WritingInstrument PaintPen = new(2, "Paint Pen", string.Empty);
        public static readonly WritingInstrument Sharpie = new(3, "Sharpie", string.Empty);

        public static readonly WritingInstrument[] All =
        {
            BallpointPen,
            PaintPen,
            Sharpie
        };

        private WritingInstrument(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static WritingInstrument Find(int id)
        {
            return All.SingleOrDefault(writingInstrument => writingInstrument.Id == id);
        }

        public static WritingInstrument Find(string name)
        {
            return All.SingleOrDefault(writingInstrument => writingInstrument.Name == name);
        }
    }
}
