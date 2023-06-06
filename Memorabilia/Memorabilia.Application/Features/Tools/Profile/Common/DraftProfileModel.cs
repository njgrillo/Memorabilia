namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class DraftProfileModel
{
    private readonly Entity.Draft _draft;

    public DraftProfileModel(Entity.Draft draft)
    {
        _draft = draft;
    }

    public int FranchiseId 
        => _draft.FranchiseId;

    public string FranchiseName 
        => Constant.Franchise.Find(FranchiseId)?.Name;

    public int? Overall 
        => _draft.Overall;

    public int? Pick 
        => _draft.Pick;

    public int Round 
        => _draft.Round;

    public int Year 
        => _draft.Year;

    public override string ToString()
        => $"{FranchiseName} - {Year} - Round {Round}, Pick {Pick} - {Overall} Overall";
}
