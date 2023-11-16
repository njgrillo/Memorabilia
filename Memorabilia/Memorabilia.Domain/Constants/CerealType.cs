namespace Memorabilia.Domain.Constants;

public sealed class CerealType : DomainItemConstant
{
    public static readonly CerealType None = new(3, "None");
    public static readonly CerealType Other = new(2, "Other");
    public static readonly CerealType Unknown = new(4, "Unknown");
    public static readonly CerealType Wheaties = new(1, "Wheaties");

    public static readonly CerealType[] All =
    [
        None,
        Other,
        Unknown,
        Wheaties
    ];

    private CerealType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static CerealType Find(int id)
        => All.SingleOrDefault(CerealType => CerealType.Id == id);
}
