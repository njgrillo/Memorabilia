namespace Memorabilia.Application.Features.Admin.Teams.Management.HallOfFames;

public class FranchiseHallOfFamesEditModel : EditModel
{
    public FranchiseHallOfFamesEditModel() { }

    public FranchiseHallOfFamesEditModel(int franchiseId, Entity.FranchiseHallOfFame[] hallOfFames)
    {        
        FranchiseHallOfFameType = Constant.FranchiseHallOfFameType.Find(franchiseId);
        FranchiseId = franchiseId;
        HallOfFames = hallOfFames.Select(x => new FranchiseHallOfFameEditModel(x)).ToList();
    }

    public Constant.FranchiseHallOfFameType FranchiseHallOfFameType { get; set; }

    public int FranchiseId { get; set; }

    public string FranchiseName
        => Constant.Franchise.Find(FranchiseId)?.Name;

    public List<FranchiseHallOfFameEditModel> HallOfFames { get; set; }
        = [];    
}
