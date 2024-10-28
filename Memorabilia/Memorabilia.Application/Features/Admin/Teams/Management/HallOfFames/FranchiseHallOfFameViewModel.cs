namespace Memorabilia.Application.Features.Admin.Teams.Management.HallOfFames;

public class FranchiseHallOfFameViewModel
{
    private readonly Entity.FranchiseHallOfFame _hallOfFame;

    public FranchiseHallOfFameViewModel() { }

    public FranchiseHallOfFameViewModel(Entity.FranchiseHallOfFame hallOfFame)
    {
        _hallOfFame = hallOfFame;
    }

    public Constant.Franchise Franchise
        => Constant.Franchise.Find(_hallOfFame.FranchiseId);

    public string FranchiseName
        => Constant.Franchise.Find(_hallOfFame.FranchiseId)?.Name;

    public int Id
        => _hallOfFame.Id;

    public int PersonId
        => _hallOfFame.PersonId;    

    public int? Year
        => _hallOfFame.Year;
}
