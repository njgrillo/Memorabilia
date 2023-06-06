namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class FranchiseHallOfFameProfileModel
{
    private readonly Entity.FranchiseHallOfFame _hallOfFame;

    public FranchiseHallOfFameProfileModel(Entity.FranchiseHallOfFame hallOfFame)
    {
        _hallOfFame = hallOfFame;
    }

    public string FranchiseHallOfFameName 
        => Constant.FranchiseHallOfFameType.Find(FranchiseId)?.Name;

    public int FranchiseId 
        => _hallOfFame.FranchiseId;

    public string FranchiseName 
        => Constant.Franchise.Find(FranchiseId)?.Name;

    public string Year 
        => _hallOfFame.Year.HasValue 
        ? _hallOfFame.Year.ToString() 
        : string.Empty;
}
