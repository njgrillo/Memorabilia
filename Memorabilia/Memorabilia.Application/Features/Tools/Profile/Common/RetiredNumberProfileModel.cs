namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class RetiredNumberProfileModel
{
    private readonly Entity.RetiredNumber _retiredNumber;

    public RetiredNumberProfileModel(Entity.RetiredNumber retiredNumber)
    {
        _retiredNumber = retiredNumber;
    }

    public Constant.Franchise Franchise 
        => Constant.Franchise.Find(FranchiseId);

    public int FranchiseId 
        => _retiredNumber.FranchiseId;

    public string FranchiseName 
        => Franchise?.Name;

    public int Number 
        => _retiredNumber.PlayerNumber;
}
