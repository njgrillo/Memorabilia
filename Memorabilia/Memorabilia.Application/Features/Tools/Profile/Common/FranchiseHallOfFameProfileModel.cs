namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class FranchiseHallOfFameProfileModel(Entity.FranchiseHallOfFame hallOfFame)
{
    public string FranchiseHallOfFameName 
        => Constant.FranchiseHallOfFameType.Find(FranchiseId)?.Name;

    public int FranchiseId 
        => hallOfFame.FranchiseId;

    public string FranchiseName 
        => Constant.Franchise.Find(FranchiseId)?.Name;

    public string Year 
        => hallOfFame.Year.HasValue 
            ? hallOfFame.Year.ToString() 
            : string.Empty;
}
