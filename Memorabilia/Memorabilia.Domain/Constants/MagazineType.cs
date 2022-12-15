namespace Memorabilia.Domain.Constants;

public sealed class MagazineType : DomainItemConstant
{
    public static readonly MagazineType StandardPublication = new(1, "Standard Publication");
    public static readonly MagazineType Program = new(2, "Program");

    public static readonly MagazineType[] All =
    {
        StandardPublication,
        Program
    };

    private MagazineType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static MagazineType Find(int id)
    {
        return All.SingleOrDefault(magazineType => magazineType.Id == id);
    }
}
