namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class DraftProfileModel(Entity.Draft draft)
{
    public int FranchiseId 
        => draft.FranchiseId;

    public string FranchiseName 
        => Constant.Franchise.Find(FranchiseId)?.Name;

    public int? Overall 
        => draft.Overall;

    public int? Pick 
        => draft.Pick;

    public int Round 
        => draft.Round;

    public int Year 
        => draft.Year;

    public override string ToString()
        => $"{FranchiseName} - {Year} - Round {Round}, Pick {Pick} - {Overall} Overall";
}
