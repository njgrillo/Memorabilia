namespace Memorabilia.Application.Features.Admin.People;

public class PersonDraftEditModel : EditModel
{
    public PersonDraftEditModel() { }

    public PersonDraftEditModel(int[] sportIds)
    {
        Sports = sportIds.Select(Constant.Sport.Find)
                         .ToArray();
    }

    public PersonDraftEditModel(Entity.Draft draft)
    {
        Franchise = Constant.Franchise.Find(draft.FranchiseId);
        Id = draft.Id;
        Overall = draft.Overall;
        PersonId = draft.PersonId;
        Pick = draft.Pick;
        Round = draft.Round;    
        Year = draft.Year;
    }

    public Constant.Franchise Franchise { get; set; }

    public string FranchiseName 
        => Franchise?.Name;

    public int? Overall { get; set; }

    public int PersonId { get; set; }

    public int? Pick { get; set; }

    public int? Round { get; set; }

    public Constant.Sport[] Sports { get; set; } 
        = Array.Empty<Constant.Sport>();

    public int? Year { get; set; }
}
