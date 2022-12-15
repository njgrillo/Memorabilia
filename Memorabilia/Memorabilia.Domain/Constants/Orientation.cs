namespace Memorabilia.Domain.Constants;

public sealed class Orientation : DomainItemConstant
{
    public static readonly Orientation Portrait = new(1, "Portrait");
    public static readonly Orientation Landscape = new(2, "Landscape");

    public static readonly Orientation[] All =
    {
        Portrait,
        Landscape
    };

    private Orientation(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static Orientation Find(int id)
    {
        return All.SingleOrDefault(orientation => orientation.Id == id);
    }
}
