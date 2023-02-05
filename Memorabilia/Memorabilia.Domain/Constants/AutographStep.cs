namespace Memorabilia.Domain.Constants;

public sealed class AutographStep : DomainItemConstant
{
    public static readonly AutographStep Autograph = new(1, "Autograph");
    public static readonly AutographStep Authentication = new(3, "Authentications");        
    public static readonly AutographStep Image = new(5, "Images");
    public static readonly AutographStep Inscription = new(2, "Inscriptions");
    public static readonly AutographStep Spot = new(4, "Spot");

    public static readonly AutographStep[] All =
    {
       Autograph,
       Authentication,
       Image,
       Inscription,
       Spot
    };

    private AutographStep(int id, string name) 
        : base(id, name) { }

    public static AutographStep Find(int id)
        => All.SingleOrDefault(autographStep => autographStep.Id == id);
}
