namespace Memorabilia.Application.Features.Admin.Teams.Management.HallOfFames;

public class FranchiseHallOfFamesViewModel
{
    private readonly int _franchiseId;
    private readonly Entity.FranchiseHallOfFame[] _hallOfFamers;    

    public FranchiseHallOfFamesViewModel() { }

    public FranchiseHallOfFamesViewModel(int franchiseId, Entity.FranchiseHallOfFame[] hallOfFamers)
    {
        _hallOfFamers = hallOfFamers;
        _franchiseId = franchiseId;
    }

    public int FranchiseId
        => _franchiseId;

    public Entity.FranchiseHallOfFame[] HallOfFamers
        => _hallOfFamers;
}
