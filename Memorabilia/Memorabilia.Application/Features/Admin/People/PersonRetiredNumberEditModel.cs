namespace Memorabilia.Application.Features.Admin.People;

public class PersonRetiredNumberEditModel : EditModel
{
    public PersonRetiredNumberEditModel() { }

    public PersonRetiredNumberEditModel(Entity.RetiredNumber retiredNumber)
    {
        Franchise = Constant.Franchise.Find(retiredNumber.FranchiseId);
        Id = retiredNumber.Id;
        PersonId = retiredNumber.PersonId;
        PlayerNumber = retiredNumber.PlayerNumber;
    }

    public Constant.Franchise Franchise { get; set; }

    public string FranchiseName 
        => Franchise?.Name;    

    public int PersonId { get; set; }

    public int? PlayerNumber { get; set; }
}
