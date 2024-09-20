namespace Memorabilia.Application.Features.Admin.People.Management.Drafts;

public class DraftEditModel : EditModel
{
    public DraftEditModel()
    {
        TemporaryId = Guid.NewGuid();
    }

    public DraftEditModel(Entity.Draft draft)
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

    public Guid? TemporaryId { get; set; }

    public int? Year { get; set; }

    public void Set(int franchiseId, int year, int round, int? pick, int? overall)
    {
        Franchise = Constant.Franchise.Find(franchiseId);
        Overall = overall;
        Pick = pick;
        Round = round;
        Year = year;
    }

    public void Set(int id, int franchiseId, int year, int round, int? pick, int? overall)
    {        
        Franchise = Constant.Franchise.Find(franchiseId);
        Id = id;
        Overall = overall;
        Pick = pick;
        Round = round;
        Year = year;
    }
}
