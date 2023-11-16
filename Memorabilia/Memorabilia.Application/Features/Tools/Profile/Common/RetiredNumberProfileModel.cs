namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class RetiredNumberProfileModel(Entity.RetiredNumber retiredNumber)
{
    public Constant.Franchise Franchise 
        => Constant.Franchise.Find(FranchiseId);

    public int FranchiseId 
        => retiredNumber.FranchiseId;

    public string FranchiseName 
        => Franchise?.Name;

    public int Number 
        => retiredNumber.PlayerNumber;
}
