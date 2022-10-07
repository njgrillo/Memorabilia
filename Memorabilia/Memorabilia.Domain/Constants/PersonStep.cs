namespace Memorabilia.Domain.Constants;

public sealed class PersonStep : DomainItemConstant
{
    public static readonly PersonStep Accolade = new(5, "Accolades");
    public static readonly PersonStep HallOfFame = new(6, "Hall Of Fames");
    public static readonly PersonStep Image = new(7, "Image");
    public static readonly PersonStep Occupation = new(2, "Occupations");
    public static readonly PersonStep Person = new(1, "Person");
    public static readonly PersonStep SportService = new(3, "Sport Service");
    public static readonly PersonStep Team = new(4, "Teams");

    public static readonly PersonStep[] All =
    {
       Accolade,
       HallOfFame,
       Image,
       Occupation,
       Person,
       SportService,
       Team
    };

    private PersonStep(int id, string name) : base(id, name) { }

    public static PersonStep Find(int id)
    {
        return All.SingleOrDefault(personStep => personStep.Id == id);
    }
}
