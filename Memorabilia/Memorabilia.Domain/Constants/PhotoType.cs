namespace Memorabilia.Domain.Constants;

public sealed class PhotoType : DomainItemConstant
{
    public static readonly PhotoType Glossy = new(1, "Glossy");
    public static readonly PhotoType Matte = new(2, "Matte");
    public static readonly PhotoType Unknown = new(3, "Unknown");

    public static readonly PhotoType[] All =
    [
        Glossy,
        Matte,
        Unknown
    ];

    private PhotoType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static PhotoType Find(int id)
        => All.SingleOrDefault(photoType => photoType.Id == id);
}
