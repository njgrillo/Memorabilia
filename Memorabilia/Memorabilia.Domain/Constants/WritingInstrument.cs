namespace Memorabilia.Domain.Constants;

public sealed class WritingInstrument : DomainItemConstant
{
    public static readonly WritingInstrument BallpointPen = new(1, "Ballpoint Pen");
    public static readonly WritingInstrument Other = new(6, "Other");
    public static readonly WritingInstrument PaintPen = new(2, "Paint Pen");
    public static readonly WritingInstrument Sharpie = new(3, "Sharpie");
    public static readonly WritingInstrument Unknown = new(7, "Unknown");

    public static readonly WritingInstrument[] All =
    {
        BallpointPen,
        Other,
        PaintPen,
        Sharpie,
        Unknown
    };

    private WritingInstrument(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static WritingInstrument Find(int id)
    {
        return All.SingleOrDefault(writingInstrument => writingInstrument.Id == id);
    }

    public static WritingInstrument Find(string name)
    {
        return All.SingleOrDefault(writingInstrument => writingInstrument.Name == name);
    }
}
