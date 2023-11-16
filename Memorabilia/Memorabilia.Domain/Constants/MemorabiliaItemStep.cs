namespace Memorabilia.Domain.Constants;

public sealed class MemorabiliaItemStep : DomainItemConstant
{
    public static readonly MemorabiliaItemStep Detail = new(2, "Details");
    public static readonly MemorabiliaItemStep Image = new(3, "Images");
    public static readonly MemorabiliaItemStep Item = new(1, "Memorabilia");    

    public static readonly MemorabiliaItemStep[] All =
    [
       Detail,
       Image,
       Item
    ];

    private MemorabiliaItemStep(int id, string name) 
        : base(id, name) { }

    public static MemorabiliaItemStep Find(int id)
        => All.SingleOrDefault(memorabiliaItemStep => memorabiliaItemStep.Id == id);
}
