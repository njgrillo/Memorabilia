namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonDraftApiModel
{
    private readonly Entity.Draft _draft;

    public PersonDraftApiModel(Entity.Draft draft)
    {
        _draft = draft;
    }

    public string Franchise
        => Constant.Franchise.Find(_draft.FranchiseId).Name;

    public int? Overall
        => _draft.Overall;

    public int? Pick
        => _draft.Pick;

    public int Round
        => _draft.Round;

    public int Year
        => _draft.Year;
}
