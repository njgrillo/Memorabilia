namespace Memorabilia.Domain.Constants;

public sealed class Condition : DomainItemConstant
{  
    public static readonly Condition Excellent = new(5, "Excellent");
    public static readonly Condition Fair = new(6, "Fair");
    public static readonly Condition GemMint = new(2, "Gem Mint");
    public static readonly Condition Mint = new(3, "Mint");
    public static readonly Condition NearMint = new(4, "Near Mint");
    public static readonly Condition Poor = new(7, "Poor");
    public static readonly Condition Pristine = new(1, "Pristine");
    public static readonly Condition Unknown = new(11, "Unknown");

    public static readonly Condition[] All =
    {
        Pristine,
        GemMint,
        Mint,
        NearMint,
        Excellent,
        Fair,
        Poor,
        Unknown
    };

    private Condition(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static Condition Find(int id)
        => All.SingleOrDefault(condition => condition.Id == id);

    public static Condition Find(string name)
        => All.SingleOrDefault(condition => condition.Name == name);    
}
